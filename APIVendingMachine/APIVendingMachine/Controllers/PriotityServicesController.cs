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
    public class PriotityServicesController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/PriotityServices
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все PriotityService")]
        public IQueryable<PriotityService> GetPriotityService()
        {
            return db.PriotityService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/PriotityServices/5
        [ResponseType(typeof(PriotityService))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает PriotityService по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда PriotityService по указоному Id не найден")]
        public IHttpActionResult GetPriotityService(int id)
        {
            PriotityService priotityService = db.PriotityService.Find(id);
            if (priotityService == null)
            {
                return NotFound();
            }

            return Ok(priotityService);
        }

        // PUT: api/PriotityServices/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  PriotityService успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  PriotityService не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  PriotityService по указоному Id не найден")]
        public IHttpActionResult PutPriotityService(int id, PriotityService priotityService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priotityService.Id)
            {
                return BadRequest();
            }

            db.Entry(priotityService).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriotityServiceExists(id))
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

        // POST: api/PriotityServices
        [ResponseType(typeof(PriotityService))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда PriotityService успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда PriotityService не валиден")]
        public IHttpActionResult PostPriotityService(PriotityService priotityService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PriotityService.Add(priotityService);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = priotityService.Id }, priotityService);
        }

        // DELETE: api/PriotityServices/5
        [ResponseType(typeof(PriotityService))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда PriotityService успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда PriotityService по указоному Id не найден")]
        public IHttpActionResult DeletePriotityService(int id)
        {
            PriotityService priotityService = db.PriotityService.Find(id);
            if (priotityService == null)
            {
                return NotFound();
            }

            db.PriotityService.Remove(priotityService);
            db.SaveChanges();

            return Ok(priotityService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PriotityServiceExists(int id)
        {
            return db.PriotityService.Count(e => e.Id == id) > 0;
        }
    }
}