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
    public class ProductMatrixsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/ProductMatrixs
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все ProductMatrix")]
        public IQueryable<ProductMatrix> GetProductMatrix()
        {
            return db.ProductMatrix;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ProductMatrixs/5
        [ResponseType(typeof(ProductMatrix))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает ProductMatrix по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда ProductMatrix по указоному Id не найден")]
        public IHttpActionResult GetProductMatrix(int id)
        {
            ProductMatrix productMatrix = db.ProductMatrix.Find(id);
            if (productMatrix == null)
            {
                return NotFound();
            }

            return Ok(productMatrix);
        }

        // PUT: api/ProductMatrixs/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  ProductMatrix успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  ProductMatrix не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  ProductMatrix по указоному Id не найден")]
        public IHttpActionResult PutProductMatrix(int id, ProductMatrix productMatrix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productMatrix.Id)
            {
                return BadRequest();
            }

            db.Entry(productMatrix).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMatrixExists(id))
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

        // POST: api/ProductMatrixs
        [ResponseType(typeof(ProductMatrix))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда ProductMatrix успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда ProductMatrix не валиден")]
        public IHttpActionResult PostProductMatrix(ProductMatrix productMatrix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductMatrix.Add(productMatrix);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productMatrix.Id }, productMatrix);
        }

        // DELETE: api/ProductMatrixs/5
        [ResponseType(typeof(ProductMatrix))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда ProductMatrix успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда ProductMatrix по указоному Id не найден")]
        public IHttpActionResult DeleteProductMatrix(int id)
        {
            ProductMatrix productMatrix = db.ProductMatrix.Find(id);
            if (productMatrix == null)
            {
                return NotFound();
            }

            db.ProductMatrix.Remove(productMatrix);
            db.SaveChanges();

            return Ok(productMatrix);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductMatrixExists(int id)
        {
            return db.ProductMatrix.Count(e => e.Id == id) > 0;
        }
    }
}