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
    public class TPuestoesController : ApiController
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: api/TPuestoes
        public IQueryable<TPuesto> GetTPuestoes()
        {
            return db.TPuestoes;
        }

        // GET: api/TPuestoes/5
        [ResponseType(typeof(TPuesto))]
        public IHttpActionResult GetTPuesto(int id)
        {
            TPuesto tPuesto = db.TPuestoes.Find(id);
            if (tPuesto == null)
            {
                return NotFound();
            }

            return Ok(tPuesto);
        }

        // PUT: api/TPuestoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTPuesto(int id, TPuesto tPuesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tPuesto.IdPuesto)
            {
                return BadRequest();
            }

            db.Entry(tPuesto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TPuestoExists(id))
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

        // POST: api/TPuestoes
        [ResponseType(typeof(TPuesto))]
        public IHttpActionResult PostTPuesto(TPuesto tPuesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TPuestoes.Add(tPuesto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tPuesto.IdPuesto }, tPuesto);
        }

        // DELETE: api/TPuestoes/5
        [ResponseType(typeof(TPuesto))]
        public IHttpActionResult DeleteTPuesto(int id)
        {
            TPuesto tPuesto = db.TPuestoes.Find(id);
            if (tPuesto == null)
            {
                return NotFound();
            }

            db.TPuestoes.Remove(tPuesto);
            db.SaveChanges();

            return Ok(tPuesto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TPuestoExists(int id)
        {
            return db.TPuestoes.Count(e => e.IdPuesto == id) > 0;
        }
    }
}