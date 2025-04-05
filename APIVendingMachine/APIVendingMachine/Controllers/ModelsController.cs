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
    public class ModelsController : ApiController
    {
        private VendingMachinesEntities db = new VendingMachinesEntities();

        // GET: api/Models
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает все Model")]
        public IQueryable<Model> GetModel()
        {
            return db.Model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Models/5
        [ResponseType(typeof(Model))]
        [SwaggerResponse(HttpStatusCode.OK, Description ="Возращает Model по Id")]
[SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда Model по указоному Id не найден")]
        public IHttpActionResult GetModel(int id)
        {
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Models/5
        [ResponseType(typeof(void))]
         [SwaggerResponse(HttpStatusCode.NoContent, Description = "Возращает когда  Model успешно изменен")]
 [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда  Model не валиден")]
 [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда  Model по указоному Id не найден")]
        public IHttpActionResult PutModel(int id, Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Models
        [ResponseType(typeof(Model))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Возращает когда Model успешно сохранен в Базе Данных")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Возращает когда Model не валиден")]
        public IHttpActionResult PostModel(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Model.Add(model);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        // DELETE: api/Models/5
        [ResponseType(typeof(Model))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает когда Model успешно удален из Базы Данных")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Возращает когда Model по указоному Id не найден")]
        public IHttpActionResult DeleteModel(int id)
        {
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Model.Remove(model);
            db.SaveChanges();

            return Ok(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelExists(int id)
        {
            return db.Model.Count(e => e.Id == id) > 0;
        }
    }
}