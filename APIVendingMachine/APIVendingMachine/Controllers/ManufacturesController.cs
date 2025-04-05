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
    public class ManufacturesController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/Manufactures
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все Manufacture")]
        public IQueryable<Manufacture> GetManufacture()
        {
            return db.Manufacture;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Manufactures/5
        [ResponseType(typeof(Manufacture))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает Manufacture по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда Manufacture по указоному Id не найден")]
        public IHttpActionResult GetManufacture(int id)
        {
            Manufacture manufacture = db.Manufacture.Find(id);
            if (manufacture == null)
            {
                return NotFound();
            }

            return Ok(manufacture);
        }

        // PUT: api/Manufactures/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  Manufacture успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  Manufacture не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  Manufacture по указоному Id не найден")]
        public IHttpActionResult PutManufacture(int id, Manufacture manufacture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacture.Id)
            {
                return BadRequest();
            }

            db.Entry(manufacture).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufactureExists(id))
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

        // POST: api/Manufactures
        [ResponseType(typeof(Manufacture))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда Manufacture успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда Manufacture не валиден")]
        public IHttpActionResult PostManufacture(Manufacture manufacture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Manufacture.Add(manufacture);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = manufacture.Id }, manufacture);
        }

        // DELETE: api/Manufactures/5
        [ResponseType(typeof(Manufacture))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда Manufacture успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда Manufacture по указоному Id не найден")]
        public IHttpActionResult DeleteManufacture(int id)
        {
            Manufacture manufacture = db.Manufacture.Find(id);
            if (manufacture == null)
            {
                return NotFound();
            }

            db.Manufacture.Remove(manufacture);
            db.SaveChanges();

            return Ok(manufacture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManufactureExists(int id)
        {
            return db.Manufacture.Count(e => e.Id == id) > 0;
        }
    }
}