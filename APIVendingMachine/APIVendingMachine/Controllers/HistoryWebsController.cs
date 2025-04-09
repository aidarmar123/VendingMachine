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
    public class HistoryWebsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/HistoryWebs
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все HistoryWeb")]
        public IQueryable<HistoryWeb> GetHistoryWeb()
        {
            return db.HistoryWeb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/HistoryWebs/5
        [ResponseType(typeof(HistoryWeb))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает HistoryWeb по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда HistoryWeb по указоному Id не найден")]
        public IHttpActionResult GetHistoryWeb(int id)
        {
            HistoryWeb historyWeb = db.HistoryWeb.Find(id);
            if (historyWeb == null)
            {
                return NotFound();
            }

            return Ok(historyWeb);
        }

        // PUT: api/HistoryWebs/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  HistoryWeb успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  HistoryWeb не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  HistoryWeb по указоному Id не найден")]
        public IHttpActionResult PutHistoryWeb(int id, HistoryWeb historyWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historyWeb.Id)
            {
                return BadRequest();
            }

            db.Entry(historyWeb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryWebExists(id))
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

        // POST: api/HistoryWebs
        [ResponseType(typeof(HistoryWeb))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда HistoryWeb успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда HistoryWeb не валиден")]
        public IHttpActionResult PostHistoryWeb(HistoryWeb historyWeb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistoryWeb.Add(historyWeb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = historyWeb.Id }, historyWeb);
        }

        // DELETE: api/HistoryWebs/5
        [ResponseType(typeof(HistoryWeb))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда HistoryWeb успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда HistoryWeb по указоному Id не найден")]
        public IHttpActionResult DeleteHistoryWeb(int id)
        {
            HistoryWeb historyWeb = db.HistoryWeb.Find(id);
            if (historyWeb == null)
            {
                return NotFound();
            }

            db.HistoryWeb.Remove(historyWeb);
            db.SaveChanges();

            return Ok(historyWeb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoryWebExists(int id)
        {
            return db.HistoryWeb.Count(e => e.Id == id) > 0;
        }
    }
}