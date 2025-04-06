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
    public class ShcemaCritValuesController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/ShcemaCritValues
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все ShcemaCritValue")]
        public IQueryable<ShcemaCritValue> GetShcemaCritValue()
        {
            return db.ShcemaCritValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ShcemaCritValues/5
        [ResponseType(typeof(ShcemaCritValue))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает ShcemaCritValue по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда ShcemaCritValue по указоному Id не найден")]
        public IHttpActionResult GetShcemaCritValue(int id)
        {
            ShcemaCritValue shcemaCritValue = db.ShcemaCritValue.Find(id);
            if (shcemaCritValue == null)
            {
                return NotFound();
            }

            return Ok(shcemaCritValue);
        }

        // PUT: api/ShcemaCritValues/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  ShcemaCritValue успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  ShcemaCritValue не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  ShcemaCritValue по указоному Id не найден")]
        public IHttpActionResult PutShcemaCritValue(int id, ShcemaCritValue shcemaCritValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shcemaCritValue.Id)
            {
                return BadRequest();
            }

            db.Entry(shcemaCritValue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShcemaCritValueExists(id))
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

        // POST: api/ShcemaCritValues
        [ResponseType(typeof(ShcemaCritValue))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда ShcemaCritValue успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда ShcemaCritValue не валиден")]
        public IHttpActionResult PostShcemaCritValue(ShcemaCritValue shcemaCritValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShcemaCritValue.Add(shcemaCritValue);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shcemaCritValue.Id }, shcemaCritValue);
        }

        // DELETE: api/ShcemaCritValues/5
        [ResponseType(typeof(ShcemaCritValue))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда ShcemaCritValue успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда ShcemaCritValue по указоному Id не найден")]
        public IHttpActionResult DeleteShcemaCritValue(int id)
        {
            ShcemaCritValue shcemaCritValue = db.ShcemaCritValue.Find(id);
            if (shcemaCritValue == null)
            {
                return NotFound();
            }

            db.ShcemaCritValue.Remove(shcemaCritValue);
            db.SaveChanges();

            return Ok(shcemaCritValue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShcemaCritValueExists(int id)
        {
            return db.ShcemaCritValue.Count(e => e.Id == id) > 0;
        }
    }
}