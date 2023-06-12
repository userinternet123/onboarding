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
    public class TAreasController : ApiController
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: api/TAreas
        public IQueryable<TArea> GetTAreas()
        {
            return db.TAreas;
        }

        // GET: api/TAreas/5
        [ResponseType(typeof(TArea))]
        public IHttpActionResult GetTArea(int id)
        {
            TArea tArea = db.TAreas.Find(id);
            if (tArea == null)
            {
                return NotFound();
            }

            return Ok(tArea);
        }

        // PUT: api/TAreas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTArea(int id, TArea tArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tArea.IdArea)
            {
                return BadRequest();
            }

            db.Entry(tArea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TAreaExists(id))
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

        // POST: api/TAreas
        [ResponseType(typeof(TArea))]
        public IHttpActionResult PostTArea(TArea tArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TAreas.Add(tArea);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tArea.IdArea }, tArea);
        }

        // DELETE: api/TAreas/5
        [ResponseType(typeof(TArea))]
        public IHttpActionResult DeleteTArea(int id)
        {
            TArea tArea = db.TAreas.Find(id);
            if (tArea == null)
            {
                return NotFound();
            }

            db.TAreas.Remove(tArea);
            db.SaveChanges();

            return Ok(tArea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TAreaExists(int id)
        {
            return db.TAreas.Count(e => e.IdArea == id) > 0;
        }
    }
}