using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using onBoardingApi.Models;

namespace onBoardingApi.Controllers.Api
{
    public class TAsignacionsController : ApiController
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: api/TAsignacions
        public IQueryable<TAsignacion> GetTAsignacions()
        {
            return db.TAsignacions;
        }

        // GET: api/TAsignacions/5
        [ResponseType(typeof(TAsignacion))]
        public IHttpActionResult GetTAsignacion(int id)
        {
            TAsignacion tAsignacion = db.TAsignacions.Find(id);
            if (tAsignacion == null)
            {
                return NotFound();
            }

            return Ok(tAsignacion);
        }

        // PUT: api/TAsignacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTAsignacion(int id, TAsignacion tAsignacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tAsignacion.IdRecursoPuestoEmpleado)
            {
                return BadRequest();
            }

            db.Entry(tAsignacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TAsignacionExists(id))
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

        // POST: api/TAsignacions
        [ResponseType(typeof(TAsignacion))]
        public IHttpActionResult PostTAsignacion(TAsignacion tAsignacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TAsignacions.Add(tAsignacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tAsignacion.IdRecursoPuestoEmpleado }, tAsignacion);
        }

        // DELETE: api/TAsignacions/5
        [ResponseType(typeof(TAsignacion))]
        public IHttpActionResult DeleteTAsignacion(int id)
        {
            TAsignacion tAsignacion = db.TAsignacions.Find(id);
            if (tAsignacion == null)
            {
                return NotFound();
            }

            db.TAsignacions.Remove(tAsignacion);
            db.SaveChanges();

            return Ok(tAsignacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TAsignacionExists(int id)
        {
            return db.TAsignacions.Count(e => e.IdRecursoPuestoEmpleado == id) > 0;
        }
    }
}