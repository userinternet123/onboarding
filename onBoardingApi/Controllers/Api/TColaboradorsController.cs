using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using onBoardingApi.Models;

namespace onBoardingApi.Controllers.Api
{
    [AllowAnonymous]
    [RoutePrefix("api/puesto")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TColaboradorsController : ApiController
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: api/TColaboradors
        [Route("listar")]
        [HttpGet]
        [ResponseType(typeof(List<TPuesto>))]
        public IHttpActionResult GetTColaboradors()
        {
            try
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                var result = db.TColaboradors.Where(x => x.Eliminado == false).ToList();
                var puesto = db.TPuestoes.ToList();
                var final = result.Select(x => new
                {
                   x.IdColaborador,
                   x.NombreColaborador,
                   x.DPIColaborador,
                   x.FechaIngreso,
                   x.FechaAlta,
                   NombrePuesto = puesto.Where(y=>y.IdPuesto==x.IdPuesto).FirstOrDefault().NombrePuesto
                });
                return Ok(final);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex.GetBaseException());
            }
        }

        // GET: api/TColaboradors/5
        [ResponseType(typeof(TColaborador))]
        public IHttpActionResult GetTColaborador(int id)
        {
            TColaborador tColaborador = db.TColaboradors.Find(id);
            if (tColaborador == null)
            {
                return NotFound();
            }

            return Ok(tColaborador);
        }

        // PUT: api/TColaboradors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTColaborador(int id, TColaborador tColaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tColaborador.IdColaborador)
            {
                return BadRequest();
            }

            db.Entry(tColaborador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TColaboradorExists(id))
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

        // POST: api/TColaboradors
        [ResponseType(typeof(TColaborador))]
        public IHttpActionResult PostTColaborador(TColaborador tColaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TColaboradors.Add(tColaborador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tColaborador.IdColaborador }, tColaborador);
        }

        // DELETE: api/TColaboradors/5
        [ResponseType(typeof(TColaborador))]
        public IHttpActionResult DeleteTColaborador(int id)
        {
            TColaborador tColaborador = db.TColaboradors.Find(id);
            if (tColaborador == null)
            {
                return NotFound();
            }

            db.TColaboradors.Remove(tColaborador);
            db.SaveChanges();

            return Ok(tColaborador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TColaboradorExists(int id)
        {
            return db.TColaboradors.Count(e => e.IdColaborador == id) > 0;
        }
    }
}