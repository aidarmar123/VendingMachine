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
    public class WorkModesController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/WorkModes
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все WorkMode")]
        public IQueryable<WorkMode> GetWorkMode()
        {
            return db.WorkMode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/WorkModes/5
        [ResponseType(typeof(WorkMode))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает WorkMode по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда WorkMode по указоному Id не найден")]
        public IHttpActionResult GetWorkMode(int id)
        {
            WorkMode workMode = db.WorkMode.Find(id);
            if (workMode == null)
            {
                return NotFound();
            }

            return Ok(workMode);
        }

        // PUT: api/WorkModes/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  WorkMode успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  WorkMode не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  WorkMode по указоному Id не найден")]
        public IHttpActionResult PutWorkMode(int id, WorkMode workMode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workMode.Id)
            {
                return BadRequest();
            }

            db.Entry(workMode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkModeExists(id))
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

        // POST: api/WorkModes
        [ResponseType(typeof(WorkMode))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда WorkMode успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда WorkMode не валиден")]
        public IHttpActionResult PostWorkMode(WorkMode workMode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkMode.Add(workMode);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workMode.Id }, workMode);
        }

        // DELETE: api/WorkModes/5
        [ResponseType(typeof(WorkMode))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда WorkMode успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда WorkMode по указоному Id не найден")]
        public IHttpActionResult DeleteWorkMode(int id)
        {
            WorkMode workMode = db.WorkMode.Find(id);
            if (workMode == null)
            {
                return NotFound();
            }

            db.WorkMode.Remove(workMode);
            db.SaveChanges();

            return Ok(workMode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkModeExists(int id)
        {
            return db.WorkMode.Count(e => e.Id == id) > 0;
        }
    }
}