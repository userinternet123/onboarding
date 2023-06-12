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
    public class TObjetivoesController : ApiController
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: api/TObjetivoes
        public IQueryable<TObjetivo> GetTObjetivoes()
        {
            return db.TObjetivoes;
        }

        // GET: api/TObjetivoes/5
        [ResponseType(typeof(TObjetivo))]
        public IHttpActionResult GetTObjetivo(int id)
        {
            TObjetivo tObjetivo = db.TObjetivoes.Find(id);
            if (tObjetivo == null)
            {
                return NotFound();
            }

            return Ok(tObjetivo);
        }

        // PUT: api/TObjetivoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTObjetivo(int id, TObjetivo tObjetivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tObjetivo.IdObjetivo)
            {
                return BadRequest();
            }

            db.Entry(tObjetivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TObjetivoExists(id))
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

        // POST: api/TObjetivoes
        [ResponseType(typeof(TObjetivo))]
        public IHttpActionResult PostTObjetivo(TObjetivo tObjetivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TObjetivoes.Add(tObjetivo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tObjetivo.IdObjetivo }, tObjetivo);
        }

        // DELETE: api/TObjetivoes/5
        [ResponseType(typeof(TObjetivo))]
        public IHttpActionResult DeleteTObjetivo(int id)
        {
            TObjetivo tObjetivo = db.TObjetivoes.Find(id);
            if (tObjetivo == null)
            {
                return NotFound();
            }

            db.TObjetivoes.Remove(tObjetivo);
            db.SaveChanges();

            return Ok(tObjetivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TObjetivoExists(int id)
        {
            return db.TObjetivoes.Count(e => e.IdObjetivo == id) > 0;
        }
    }
}