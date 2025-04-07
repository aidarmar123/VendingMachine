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
    public class ConnectionProvidersController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/ConnectionProviders
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все ConnectionProvider")]
        public IQueryable<ConnectionProvider> GetConnectionProvider()
        {
            return db.ConnectionProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ConnectionProviders/5
        [ResponseType(typeof(ConnectionProvider))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает ConnectionProvider по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда ConnectionProvider по указоному Id не найден")]
        public IHttpActionResult GetConnectionProvider(int id)
        {
            ConnectionProvider connectionProvider = db.ConnectionProvider.Find(id);
            if (connectionProvider == null)
            {
                return NotFound();
            }

            return Ok(connectionProvider);
        }

        // PUT: api/ConnectionProviders/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  ConnectionProvider успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  ConnectionProvider не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  ConnectionProvider по указоному Id не найден")]
        public IHttpActionResult PutConnectionProvider(int id, ConnectionProvider connectionProvider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != connectionProvider.Id)
            {
                return BadRequest();
            }

            db.Entry(connectionProvider).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionProviderExists(id))
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

        // POST: api/ConnectionProviders
        [ResponseType(typeof(ConnectionProvider))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда ConnectionProvider успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда ConnectionProvider не валиден")]
        public IHttpActionResult PostConnectionProvider(ConnectionProvider connectionProvider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConnectionProvider.Add(connectionProvider);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = connectionProvider.Id }, connectionProvider);
        }

        // DELETE: api/ConnectionProviders/5
        [ResponseType(typeof(ConnectionProvider))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда ConnectionProvider успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда ConnectionProvider по указоному Id не найден")]
        public IHttpActionResult DeleteConnectionProvider(int id)
        {
            ConnectionProvider connectionProvider = db.ConnectionProvider.Find(id);
            if (connectionProvider == null)
            {
                return NotFound();
            }

            db.ConnectionProvider.Remove(connectionProvider);
            db.SaveChanges();

            return Ok(connectionProvider);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConnectionProviderExists(int id)
        {
            return db.ConnectionProvider.Count(e => e.Id == id) > 0;
        }
    }
}