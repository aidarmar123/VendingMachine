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
    public class CenterNotificationsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/CenterNotifications
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все CenterNotification")]
        public IQueryable<CenterNotification> GetCenterNotification()
        {
            return db.CenterNotification;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/CenterNotifications/5
        [ResponseType(typeof(CenterNotification))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает CenterNotification по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда CenterNotification по указоному Id не найден")]
        public IHttpActionResult GetCenterNotification(int id)
        {
            CenterNotification centerNotification = db.CenterNotification.Find(id);
            if (centerNotification == null)
            {
                return NotFound();
            }

            return Ok(centerNotification);
        }

        // PUT: api/CenterNotifications/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  CenterNotification успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  CenterNotification не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  CenterNotification по указоному Id не найден")]
        public IHttpActionResult PutCenterNotification(int id, CenterNotification centerNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != centerNotification.Id)
            {
                return BadRequest();
            }

            db.Entry(centerNotification).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenterNotificationExists(id))
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

        // POST: api/CenterNotifications
        [ResponseType(typeof(CenterNotification))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда CenterNotification успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда CenterNotification не валиден")]
        public IHttpActionResult PostCenterNotification(CenterNotification centerNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CenterNotification.Add(centerNotification);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = centerNotification.Id }, centerNotification);
        }

        // DELETE: api/CenterNotifications/5
        [ResponseType(typeof(CenterNotification))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда CenterNotification успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда CenterNotification по указоному Id не найден")]
        public IHttpActionResult DeleteCenterNotification(int id)
        {
            CenterNotification centerNotification = db.CenterNotification.Find(id);
            if (centerNotification == null)
            {
                return NotFound();
            }

            db.CenterNotification.Remove(centerNotification);
            db.SaveChanges();

            return Ok(centerNotification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CenterNotificationExists(int id)
        {
            return db.CenterNotification.Count(e => e.Id == id) > 0;
        }
    }
}