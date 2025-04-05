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
    public class SalesController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/Sales
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все Sales")]
        public IQueryable<Sales> GetSales()
        {
            return db.Sales;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Sales/5
        [ResponseType(typeof(Sales))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает Sales по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда Sales по указоному Id не найден")]
        public IHttpActionResult GetSales(int id)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }

            return Ok(sales);
        }

        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  Sales успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  Sales не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  Sales по указоному Id не найден")]
        public IHttpActionResult PutSales(int id, Sales sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sales.Id)
            {
                return BadRequest();
            }

            db.Entry(sales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
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

        // POST: api/Sales
        [ResponseType(typeof(Sales))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда Sales успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда Sales не валиден")]
        public IHttpActionResult PostSales(Sales sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sales.Add(sales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sales.Id }, sales);
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sales))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда Sales успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда Sales по указоному Id не найден")]
        public IHttpActionResult DeleteSales(int id)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sales);
            db.SaveChanges();

            return Ok(sales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesExists(int id)
        {
            return db.Sales.Count(e => e.Id == id) > 0;
        }
    }
}