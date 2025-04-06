
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
    public class TimeZonesController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/TimeZones
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все TimeZone")]
        public IQueryable<Models.TimeZone> GetTimeZone()
        {
            return db.TimeZone;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/TimeZones/5
        [ResponseType(typeof(TimeZone))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает TimeZone по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда TimeZone по указоному Id не найден")]
        public IHttpActionResult GetTimeZone(int id)
        {
            TimeZone timeZone = db.TimeZone.Find(id);
            if (timeZone == null)
            {
                return NotFound();
            }

            return Ok(timeZone);
        }

        // PUT: api/TimeZones/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  TimeZone успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  TimeZone не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  TimeZone по указоному Id не найден")]
        public IHttpActionResult PutTimeZone(int id, TimeZone timeZone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeZone.Id)
            {
                return BadRequest();
            }

            db.Entry(timeZone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeZoneExists(id))
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

        // POST: api/TimeZones
        [ResponseType(typeof(TimeZone))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда TimeZone успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда TimeZone не валиден")]
        public IHttpActionResult PostTimeZone(TimeZone timeZone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeZone.Add(timeZone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timeZone.Id }, timeZone);
        }

        // DELETE: api/TimeZones/5
        [ResponseType(typeof(TimeZone))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда TimeZone успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда TimeZone по указоному Id не найден")]
        public IHttpActionResult DeleteTimeZone(int id)
        {
            TimeZone timeZone = db.TimeZone.Find(id);
            if (timeZone == null)
            {
                return NotFound();
            }

            db.TimeZone.Remove(timeZone);
            db.SaveChanges();

            return Ok(timeZone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeZoneExists(int id)
        {
            return db.TimeZone.Count(e => e.Id == id) > 0;
        }
    }
}