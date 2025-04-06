using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using Swashbuckle.Swagger.Annotations;
using System.Web.Http;
using System.Web.Http.Description;
using APIVendingMachine.Models;

namespace APIVendingMachine.Controllers
{
    public class CompanysController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/Companys
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все Company")]
        public IQueryable<Company> GetCompany()
        {
            return db.Company;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Companys/5
        [ResponseType(typeof(Company))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает Company по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда Company по указоному Id не найден")]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Companys/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  Company успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  Company не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  Company по указоному Id не найден")]
        public IHttpActionResult PutCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(string.Join("\n", error));
            }

            if (id != company.Id)
            {
                return BadRequest();
            }

            db.Entry(company).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Companys
        [ResponseType(typeof(Company))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда Company успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда Company не валиден")]
        public IHttpActionResult PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(string.Join("\n", error));
            }

            db.Company.Add(company);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = company.Id }, company);
        }

        // DELETE: api/Companys/5
        [ResponseType(typeof(Company))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда Company успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда Company по указоному Id не найден")]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Company.Remove(company);
            db.SaveChanges();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Company.Count(e => e.Id == id) > 0;
        }
    }
}