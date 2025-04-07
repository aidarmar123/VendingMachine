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
    public class StatusReportsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/StatusReports
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все StatusReport")]
        public IQueryable<StatusReport> GetStatusReport()
        {
            return db.StatusReport;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/StatusReports/5
        [ResponseType(typeof(StatusReport))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает StatusReport по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда StatusReport по указоному Id не найден")]
        public IHttpActionResult GetStatusReport(int id)
        {
            StatusReport statusReport = db.StatusReport.Find(id);
            if (statusReport == null)
            {
                return NotFound();
            }

            return Ok(statusReport);
        }

        // PUT: api/StatusReports/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  StatusReport успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  StatusReport не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  StatusReport по указоному Id не найден")]
        public IHttpActionResult PutStatusReport(int id, StatusReport statusReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusReport.Id)
            {
                return BadRequest();
            }

            db.Entry(statusReport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusReportExists(id))
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

        // POST: api/StatusReports
        [ResponseType(typeof(StatusReport))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда StatusReport успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда StatusReport не валиден")]
        public IHttpActionResult PostStatusReport(StatusReport statusReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusReport.Add(statusReport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusReport.Id }, statusReport);
        }

        // DELETE: api/StatusReports/5
        [ResponseType(typeof(StatusReport))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда StatusReport успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда StatusReport по указоному Id не найден")]
        public IHttpActionResult DeleteStatusReport(int id)
        {
            StatusReport statusReport = db.StatusReport.Find(id);
            if (statusReport == null)
            {
                return NotFound();
            }

            db.StatusReport.Remove(statusReport);
            db.SaveChanges();

            return Ok(statusReport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusReportExists(int id)
        {
            return db.StatusReport.Count(e => e.Id == id) > 0;
        }
    }
}