using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web.Http;
using APIVendingMachine.Models;
using Microsoft.IdentityModel.Tokens;

namespace APIVendingMachine.Controllers
{
    public class AutorizationController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        [HttpPost]
        [Route("api/auth")]
        public IHttpActionResult Auth(AuthUser user)
        {
            var contextUser = db.User.FirstOrDefault(x => x.Email == user.Login && x.Password == user.Password);
            if (contextUser == null)
            {

                return Unauthorized();
            }


            var token = GenerateJwt(contextUser);
            return Ok(new { token, contextUser});
        }

        private string GenerateJwt(User contextUser)
        {
            var secretKey = ConfigurationManager.AppSettings["secretKey"];
            var issure = ConfigurationManager.AppSettings["issure"];
            var audince = ConfigurationManager.AppSettings["audince"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, contextUser.Name),
                new Claim(ClaimTypes.Surname, contextUser.Surname),
                new Claim(ClaimTypes.Email, contextUser.Email),
            };

            var token = new JwtSecurityToken(
                issure,
                audince,
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
