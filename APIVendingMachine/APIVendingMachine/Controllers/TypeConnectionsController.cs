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
    public class TypeConnectionsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/TypeConnections
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все TypeConnection")]
        public IQueryable<TypeConnection> GetTypeConnection()
        {
            return db.TypeConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/TypeConnections/5
        [ResponseType(typeof(TypeConnection))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает TypeConnection по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда TypeConnection по указоному Id не найден")]
        public IHttpActionResult GetTypeConnection(int id)
        {
            TypeConnection typeConnection = db.TypeConnection.Find(id);
            if (typeConnection == null)
            {
                return NotFound();
            }

            return Ok(typeConnection);
        }

        // PUT: api/TypeConnections/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  TypeConnection успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  TypeConnection не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  TypeConnection по указоному Id не найден")]
        public IHttpActionResult PutTypeConnection(int id, TypeConnection typeConnection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeConnection.Id)
            {
                return BadRequest();
            }

            db.Entry(typeConnection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeConnectionExists(id))
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

        // POST: api/TypeConnections
        [ResponseType(typeof(TypeConnection))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда TypeConnection успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда TypeConnection не валиден")]
        public IHttpActionResult PostTypeConnection(TypeConnection typeConnection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeConnection.Add(typeConnection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeConnection.Id }, typeConnection);
        }

        // DELETE: api/TypeConnections/5
        [ResponseType(typeof(TypeConnection))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда TypeConnection успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда TypeConnection по указоному Id не найден")]
        public IHttpActionResult DeleteTypeConnection(int id)
        {
            TypeConnection typeConnection = db.TypeConnection.Find(id);
            if (typeConnection == null)
            {
                return NotFound();
            }

            db.TypeConnection.Remove(typeConnection);
            db.SaveChanges();

            return Ok(typeConnection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeConnectionExists(int id)
        {
            return db.TypeConnection.Count(e => e.Id == id) > 0;
        }
    }
}