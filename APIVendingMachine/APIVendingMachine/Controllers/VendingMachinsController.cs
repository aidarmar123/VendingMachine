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
    public class VendingMachinsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/VendingMachins
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все VendingMachin")]
        public IQueryable<VendingMachin> GetVendingMachin()
        {
            return db.VendingMachin;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/VendingMachins/5
        [ResponseType(typeof(VendingMachin))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает VendingMachin по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда VendingMachin по указоному Id не найден")]
        public IHttpActionResult GetVendingMachin(int id)
        {
            VendingMachin vendingMachin = db.VendingMachin.Find(id);
            if (vendingMachin == null)
            {
                return NotFound();
            }

            return Ok(vendingMachin);
        }

        // PUT: api/VendingMachins/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  VendingMachin успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  VendingMachin не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  VendingMachin по указоному Id не найден")]
        public IHttpActionResult PutVendingMachin(int id, VendingMachin vendingMachin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendingMachin.Id)
            {
                return BadRequest();
            }

            db.Entry(vendingMachin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendingMachinExists(id))
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

        // POST: api/VendingMachins
        [ResponseType(typeof(VendingMachin))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда VendingMachin успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда VendingMachin не валиден")]
        public IHttpActionResult PostVendingMachin(VendingMachin vendingMachin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VendingMachin.Add(vendingMachin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vendingMachin.Id }, vendingMachin);
        }

        // DELETE: api/VendingMachins/5
        [ResponseType(typeof(VendingMachin))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда VendingMachin успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда VendingMachin по указоному Id не найден")]
        public IHttpActionResult DeleteVendingMachin(int id)
        {
            VendingMachin vendingMachin = db.VendingMachin.Find(id);
            if (vendingMachin == null)
            {
                return NotFound();
            }

            db.VendingMachin.Remove(vendingMachin);
            db.SaveChanges();

            return Ok(vendingMachin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendingMachinExists(int id)
        {
            return db.VendingMachin.Count(e => e.Id == id) > 0;
        }
    }
}