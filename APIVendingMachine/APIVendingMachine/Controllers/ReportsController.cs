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
    public class ReportsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/Reports
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает все Report")]
        public IQueryable<Report> GetReport()
        {
            return db.Report;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Reports/5
        [ResponseType(typeof(Report))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает Report по Id")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда Report по указоному Id не найден")]
        public IHttpActionResult GetReport(int id)
        {
            Report report = db.Report.Find(id);
            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        // PUT: api/Reports/5
        [ResponseType(typeof(void))]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  Report успешно изменен")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  Report не валиден")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  Report по указоному Id не найден")]
        public IHttpActionResult PutReport(int id, Report report)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage);
                return BadRequest(string.Join("\n", error));
            }

            if (id != report.Id)
            {
                return BadRequest();
            }

            db.Entry(report).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(id))
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

        // POST: api/Reports
        [ResponseType(typeof(Report))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда Report успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда Report не валиден")]
        public IHttpActionResult PostReport(Report report)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage);
                return BadRequest(string.Join("\n", error));
            }
            else if(report.DateStart>=report.DateEnd)
            {
                return BadRequest("Дата начала болльше даты конца");

            }
            var vendingMachin = db.VendingMachin.FirstOrDefault(x => x.Id == report.VendingMachinId);
            if (vendingMachin == null)
            {
                return NotFound();
            }
            else if (vendingMachin.CompanyId != null)
            {
                return BadRequest("Автомат уже забранирован");
            }

            //vendingMachin.CompanyId = report.CompanyId;
            report.VendingMachin = null;
            db.Report.Add(report);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = report.Id }, report);
        }

        // DELETE: api/Reports/5
        [ResponseType(typeof(Report))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда Report успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда Report по указоному Id не найден")]
        public IHttpActionResult DeleteReport(int id)
        {
            Report report = db.Report.Find(id);
            if (report == null)
            {
                return NotFound();
            }

            db.Report.Remove(report);
            db.SaveChanges();

            return Ok(report);
        }

        [HttpGet]
        [Route("file/{id}")]
        public IHttpActionResult GetFileByName(int id)
        {
            var material = db.Report.FirstOrDefault(m => m.Id == id);

            if (material == null)
            {
                return NotFound();
            }

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(material.ReportData)
            };

            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = $"{id}.pdf"
            };

            return ResponseMessage(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReportExists(int id)
        {
            return db.Report.Count(e => e.Id == id) > 0;
        }
    }
}