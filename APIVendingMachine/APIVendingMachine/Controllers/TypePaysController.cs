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
    public class TypePaysController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/TypePays
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все TypePay")]
        public IQueryable<TypePay> GetTypePay()
        {
            return db.TypePay;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/TypePays/5
        [ResponseType(typeof(TypePay))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает TypePay по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда TypePay по указоному Id не найден")]
        public IHttpActionResult GetTypePay(int id)
        {
            TypePay typePay = db.TypePay.Find(id);
            if (typePay == null)
            {
                return NotFound();
            }

            return Ok(typePay);
        }

        // PUT: api/TypePays/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  TypePay успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  TypePay не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  TypePay по указоному Id не найден")]
        public IHttpActionResult PutTypePay(int id, TypePay typePay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typePay.Id)
            {
                return BadRequest();
            }

            db.Entry(typePay).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePayExists(id))
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

        // POST: api/TypePays
        [ResponseType(typeof(TypePay))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда TypePay успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда TypePay не валиден")]
        public IHttpActionResult PostTypePay(TypePay typePay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypePay.Add(typePay);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typePay.Id }, typePay);
        }

        // DELETE: api/TypePays/5
        [ResponseType(typeof(TypePay))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда TypePay успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда TypePay по указоному Id не найден")]
        public IHttpActionResult DeleteTypePay(int id)
        {
            TypePay typePay = db.TypePay.Find(id);
            if (typePay == null)
            {
                return NotFound();
            }

            db.TypePay.Remove(typePay);
            db.SaveChanges();

            return Ok(typePay);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypePayExists(int id)
        {
            return db.TypePay.Count(e => e.Id == id) > 0;
        }
    }
}