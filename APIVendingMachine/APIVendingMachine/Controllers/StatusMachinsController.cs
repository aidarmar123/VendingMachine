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
    public class StatusMachinsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/StatusMachins
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все StatusMachin")]
        public IQueryable<StatusMachin> GetStatusMachin()
        {
            return db.StatusMachin;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/StatusMachins/5
        [ResponseType(typeof(StatusMachin))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает StatusMachin по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда StatusMachin по указоному Id не найден")]
        public IHttpActionResult GetStatusMachin(int id)
        {
            StatusMachin statusMachin = db.StatusMachin.Find(id);
            if (statusMachin == null)
            {
                return NotFound();
            }

            return Ok(statusMachin);
        }

        // PUT: api/StatusMachins/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  StatusMachin успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  StatusMachin не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  StatusMachin по указоному Id не найден")]
        public IHttpActionResult PutStatusMachin(int id, StatusMachin statusMachin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusMachin.Id)
            {
                return BadRequest();
            }

            db.Entry(statusMachin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusMachinExists(id))
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

        // POST: api/StatusMachins
        [ResponseType(typeof(StatusMachin))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда StatusMachin успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда StatusMachin не валиден")]
        public IHttpActionResult PostStatusMachin(StatusMachin statusMachin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusMachin.Add(statusMachin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusMachin.Id }, statusMachin);
        }

        // DELETE: api/StatusMachins/5
        [ResponseType(typeof(StatusMachin))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда StatusMachin успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда StatusMachin по указоному Id не найден")]
        public IHttpActionResult DeleteStatusMachin(int id)
        {
            StatusMachin statusMachin = db.StatusMachin.Find(id);
            if (statusMachin == null)
            {
                return NotFound();
            }

            db.StatusMachin.Remove(statusMachin);
            db.SaveChanges();

            return Ok(statusMachin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusMachinExists(int id)
        {
            return db.StatusMachin.Count(e => e.Id == id) > 0;
        }
    }
}