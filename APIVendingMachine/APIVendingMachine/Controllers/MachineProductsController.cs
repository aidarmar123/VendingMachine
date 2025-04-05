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
    public class MachineProductsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/MachineProducts
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все MachineProduct")]
        public IQueryable<MachineProduct> GetMachineProduct()
        {
            return db.MachineProduct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/MachineProducts/5
        [ResponseType(typeof(MachineProduct))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает MachineProduct по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда MachineProduct по указоному Id не найден")]
        public IHttpActionResult GetMachineProduct(int id)
        {
            MachineProduct machineProduct = db.MachineProduct.Find(id);
            if (machineProduct == null)
            {
                return NotFound();
            }

            return Ok(machineProduct);
        }

        // PUT: api/MachineProducts/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  MachineProduct успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  MachineProduct не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  MachineProduct по указоному Id не найден")]
        public IHttpActionResult PutMachineProduct(int id, MachineProduct machineProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machineProduct.Id)
            {
                return BadRequest();
            }

            db.Entry(machineProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineProductExists(id))
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

        // POST: api/MachineProducts
        [ResponseType(typeof(MachineProduct))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда MachineProduct успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда MachineProduct не валиден")]
        public IHttpActionResult PostMachineProduct(MachineProduct machineProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MachineProduct.Add(machineProduct);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = machineProduct.Id }, machineProduct);
        }

        // DELETE: api/MachineProducts/5
        [ResponseType(typeof(MachineProduct))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда MachineProduct успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда MachineProduct по указоному Id не найден")]
        public IHttpActionResult DeleteMachineProduct(int id)
        {
            MachineProduct machineProduct = db.MachineProduct.Find(id);
            if (machineProduct == null)
            {
                return NotFound();
            }

            db.MachineProduct.Remove(machineProduct);
            db.SaveChanges();

            return Ok(machineProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MachineProductExists(int id)
        {
            return db.MachineProduct.Count(e => e.Id == id) > 0;
        }
    }
}