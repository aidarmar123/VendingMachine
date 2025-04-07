using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Owin;
using Owin;
using APIVendingMachine.Models;
using APIVendingMachine.Models.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

[assembly: OwinStartup(typeof(APIVendingMachine.Startup))]

namespace APIVendingMachine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            RegistartionProvider<VendingMachin, MetaVendingMachine>();
            RegistartionProvider<Company, MetaCompany>();
            RegistartionProvider<User, MetaUser>();

            var secretKey = ConfigurationManager.AppSettings["secretKey"];
            var issure = ConfigurationManager.AppSettings["issure"];
            var audince = ConfigurationManager.AppSettings["audince"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            app.UseJwtBearerAuthentication(new Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issure,
                    ValidAudience = audince,
                    IssuerSigningKey = key,

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                }
            });
            ConfigureAuth(app);
        }

        private void RegistartionProvider<T1, T2>()
        {
            var provider = new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T1), typeof(T2));
            TypeDescriptor.AddProviderTransparent(provider, typeof(T1));
        }
    }


}
