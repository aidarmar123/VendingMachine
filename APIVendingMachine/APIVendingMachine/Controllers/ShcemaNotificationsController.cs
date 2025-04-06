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
    public class ShcemaNotificationsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/ShcemaNotifications
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все ShcemaNotification")]
        public IQueryable<ShcemaNotification> GetShcemaNotification()
        {
            return db.ShcemaNotification;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ShcemaNotifications/5
        [ResponseType(typeof(ShcemaNotification))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает ShcemaNotification по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда ShcemaNotification по указоному Id не найден")]
        public IHttpActionResult GetShcemaNotification(int id)
        {
            ShcemaNotification shcemaNotification = db.ShcemaNotification.Find(id);
            if (shcemaNotification == null)
            {
                return NotFound();
            }

            return Ok(shcemaNotification);
        }

        // PUT: api/ShcemaNotifications/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  ShcemaNotification успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  ShcemaNotification не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  ShcemaNotification по указоному Id не найден")]
        public IHttpActionResult PutShcemaNotification(int id, ShcemaNotification shcemaNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shcemaNotification.Id)
            {
                return BadRequest();
            }

            db.Entry(shcemaNotification).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShcemaNotificationExists(id))
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

        // POST: api/ShcemaNotifications
        [ResponseType(typeof(ShcemaNotification))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда ShcemaNotification успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда ShcemaNotification не валиден")]
        public IHttpActionResult PostShcemaNotification(ShcemaNotification shcemaNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShcemaNotification.Add(shcemaNotification);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shcemaNotification.Id }, shcemaNotification);
        }

        // DELETE: api/ShcemaNotifications/5
        [ResponseType(typeof(ShcemaNotification))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда ShcemaNotification успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда ShcemaNotification по указоному Id не найден")]
        public IHttpActionResult DeleteShcemaNotification(int id)
        {
            ShcemaNotification shcemaNotification = db.ShcemaNotification.Find(id);
            if (shcemaNotification == null)
            {
                return NotFound();
            }

            db.ShcemaNotification.Remove(shcemaNotification);
            db.SaveChanges();

            return Ok(shcemaNotification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShcemaNotificationExists(int id)
        {
            return db.ShcemaNotification.Count(e => e.Id == id) > 0;
        }
    }
}