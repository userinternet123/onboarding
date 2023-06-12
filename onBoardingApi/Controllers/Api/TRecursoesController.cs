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
    public class TRecursoesController : ApiController
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: api/TRecursoes
        public IQueryable<TRecurso> GetTRecursoes()
        {
            return db.TRecursoes;
        }

        // GET: api/TRecursoes/5
        [ResponseType(typeof(TRecurso))]
        public IHttpActionResult GetTRecurso(int id)
        {
            TRecurso tRecurso = db.TRecursoes.Find(id);
            if (tRecurso == null)
            {
                return NotFound();
            }

            return Ok(tRecurso);
        }

        // PUT: api/TRecursoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTRecurso(int id, TRecurso tRecurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tRecurso.IdRecurso)
            {
                return BadRequest();
            }

            db.Entry(tRecurso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRecursoExists(id))
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

        // POST: api/TRecursoes
        [ResponseType(typeof(TRecurso))]
        public IHttpActionResult PostTRecurso(TRecurso tRecurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TRecursoes.Add(tRecurso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tRecurso.IdRecurso }, tRecurso);
        }

        // DELETE: api/TRecursoes/5
        [ResponseType(typeof(TRecurso))]
        public IHttpActionResult DeleteTRecurso(int id)
        {
            TRecurso tRecurso = db.TRecursoes.Find(id);
            if (tRecurso == null)
            {
                return NotFound();
            }

            db.TRecursoes.Remove(tRecurso);
            db.SaveChanges();

            return Ok(tRecurso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TRecursoExists(int id)
        {
            return db.TRecursoes.Count(e => e.IdRecurso == id) > 0;
        }
    }
}