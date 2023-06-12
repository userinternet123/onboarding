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
    public class TDetalleEvaluacionsController : ApiController
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: api/TDetalleEvaluacions
        public IQueryable<TDetalleEvaluacion> GetTDetalleEvaluacions()
        {
            return db.TDetalleEvaluacions;
        }

        // GET: api/TDetalleEvaluacions/5
        [ResponseType(typeof(TDetalleEvaluacion))]
        public IHttpActionResult GetTDetalleEvaluacion(int id)
        {
            TDetalleEvaluacion tDetalleEvaluacion = db.TDetalleEvaluacions.Find(id);
            if (tDetalleEvaluacion == null)
            {
                return NotFound();
            }

            return Ok(tDetalleEvaluacion);
        }

        // PUT: api/TDetalleEvaluacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTDetalleEvaluacion(int id, TDetalleEvaluacion tDetalleEvaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tDetalleEvaluacion.IdDetalleEvaluacion)
            {
                return BadRequest();
            }

            db.Entry(tDetalleEvaluacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TDetalleEvaluacionExists(id))
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

        // POST: api/TDetalleEvaluacions
        [ResponseType(typeof(TDetalleEvaluacion))]
        public IHttpActionResult PostTDetalleEvaluacion(TDetalleEvaluacion tDetalleEvaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TDetalleEvaluacions.Add(tDetalleEvaluacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tDetalleEvaluacion.IdDetalleEvaluacion }, tDetalleEvaluacion);
        }

        // DELETE: api/TDetalleEvaluacions/5
        [ResponseType(typeof(TDetalleEvaluacion))]
        public IHttpActionResult DeleteTDetalleEvaluacion(int id)
        {
            TDetalleEvaluacion tDetalleEvaluacion = db.TDetalleEvaluacions.Find(id);
            if (tDetalleEvaluacion == null)
            {
                return NotFound();
            }

            db.TDetalleEvaluacions.Remove(tDetalleEvaluacion);
            db.SaveChanges();

            return Ok(tDetalleEvaluacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TDetalleEvaluacionExists(int id)
        {
            return db.TDetalleEvaluacions.Count(e => e.IdDetalleEvaluacion == id) > 0;
        }
    }
}