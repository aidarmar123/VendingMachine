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
    public class MachineTypePaysController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/MachineTypePays
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все MachineTypePay")]
        public IQueryable<MachineTypePay> GetMachineTypePay()
        {
            return db.MachineTypePay;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/MachineTypePays/5
        [ResponseType(typeof(MachineTypePay))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает MachineTypePay по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда MachineTypePay по указоному Id не найден")]
        public IHttpActionResult GetMachineTypePay(int id)
        {
            MachineTypePay machineTypePay = db.MachineTypePay.Find(id);
            if (machineTypePay == null)
            {
                return NotFound();
            }

            return Ok(machineTypePay);
        }

        // PUT: api/MachineTypePays/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  MachineTypePay успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  MachineTypePay не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  MachineTypePay по указоному Id не найден")]
        public IHttpActionResult PutMachineTypePay(int id, MachineTypePay machineTypePay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machineTypePay.Id)
            {
                return BadRequest();
            }

            db.Entry(machineTypePay).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineTypePayExists(id))
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

        // POST: api/MachineTypePays
        [ResponseType(typeof(MachineTypePay))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда MachineTypePay успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда MachineTypePay не валиден")]
        public IHttpActionResult PostMachineTypePay(MachineTypePay machineTypePay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MachineTypePay.Add(machineTypePay);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = machineTypePay.Id }, machineTypePay);
        }

        // DELETE: api/MachineTypePays/5
        [ResponseType(typeof(MachineTypePay))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда MachineTypePay успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда MachineTypePay по указоному Id не найден")]
        public IHttpActionResult DeleteMachineTypePay(int id)
        {
            MachineTypePay machineTypePay = db.MachineTypePay.Find(id);
            if (machineTypePay == null)
            {
                return NotFound();
            }

            db.MachineTypePay.Remove(machineTypePay);
            db.SaveChanges();

            return Ok(machineTypePay);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MachineTypePayExists(int id)
        {
            return db.MachineTypePay.Count(e => e.Id == id) > 0;
        }
    }
}