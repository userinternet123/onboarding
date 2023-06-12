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
    public class TTipoObjetivoesController : ApiController
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: api/TTipoObjetivoes
        public IQueryable<TTipoObjetivo> GetTTipoObjetivoes()
        {
            return db.TTipoObjetivoes;
        }

        // GET: api/TTipoObjetivoes/5
        [ResponseType(typeof(TTipoObjetivo))]
        public IHttpActionResult GetTTipoObjetivo(int id)
        {
            TTipoObjetivo tTipoObjetivo = db.TTipoObjetivoes.Find(id);
            if (tTipoObjetivo == null)
            {
                return NotFound();
            }

            return Ok(tTipoObjetivo);
        }

        // PUT: api/TTipoObjetivoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTTipoObjetivo(int id, TTipoObjetivo tTipoObjetivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tTipoObjetivo.IdTipoObjetivo)
            {
                return BadRequest();
            }

            db.Entry(tTipoObjetivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TTipoObjetivoExists(id))
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

        // POST: api/TTipoObjetivoes
        [ResponseType(typeof(TTipoObjetivo))]
        public IHttpActionResult PostTTipoObjetivo(TTipoObjetivo tTipoObjetivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TTipoObjetivoes.Add(tTipoObjetivo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tTipoObjetivo.IdTipoObjetivo }, tTipoObjetivo);
        }

        // DELETE: api/TTipoObjetivoes/5
        [ResponseType(typeof(TTipoObjetivo))]
        public IHttpActionResult DeleteTTipoObjetivo(int id)
        {
            TTipoObjetivo tTipoObjetivo = db.TTipoObjetivoes.Find(id);
            if (tTipoObjetivo == null)
            {
                return NotFound();
            }

            db.TTipoObjetivoes.Remove(tTipoObjetivo);
            db.SaveChanges();

            return Ok(tTipoObjetivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TTipoObjetivoExists(int id)
        {
            return db.TTipoObjetivoes.Count(e => e.IdTipoObjetivo == id) > 0;
        }
    }
}