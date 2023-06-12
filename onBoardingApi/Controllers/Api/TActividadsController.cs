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
    [RoutePrefix("api/actividad")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TActividadsController : ApiController
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: api/TActividads
        [Route("listar")]
        [HttpGet]
        [ResponseType(typeof(List<TActividad>))]
        public IHttpActionResult GetTActividads()
        {
            try
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                var result = db.TActividads.Where(x => x.Eliminado == false).ToList();
                var objetivos = db.TObjetivoes.ToList();
                var final = result.Select(x => new {
                    x.IdActividad,
                    x.NombreActividad,
                    x.Peso,
                    NombreObjetivo = objetivos.Where(y=>y.IdObjetivo==x.IdObjetivo).FirstOrDefault().NombreObjetivo
                });
                return Ok(final);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex.GetBaseException());
            }
           
        }

        // GET: api/TActividads/5
        [Route("buscar/{id}")]
        [HttpGet]
        [ResponseType(typeof(TActividad))]
        public IHttpActionResult GetTActividad(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            TActividad tActividad = db.TActividads.Where(x=>x.Eliminado!=false && x.IdActividad == id).FirstOrDefault();
            if (tActividad == null)
            {
                return NotFound();
            }

            return Ok(tActividad);
        }

        // PosT: api/TActividads/5
        [Route("actualizar/{id}")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult ActualizaTActividad(int id,[FromBody] TActividad tActividad)
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tActividad.IdActividad)
            {
                return BadRequest();
            }

            db.Entry(tActividad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TActividadExists(id))
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

        // POST: api/TActividads
        [Route("agregar")]
        [HttpPost]
        [ResponseType(typeof(TActividad))]
        public IHttpActionResult PostTActividad([FromBody]TActividad tActividad)
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TActividads.Add(tActividad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tActividad.IdActividad }, tActividad);
        }

        // DELETE: api/TActividads/5
        [Route("eliminar")]
        [HttpPost]
        [ResponseType(typeof(TActividad))]
        public IHttpActionResult DeleteTActividad(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            TActividad tActividad = db.TActividads.Find(id);
            if (tActividad == null)
            {
                return NotFound();
            }
            tActividad.Eliminado = true;
            db.SaveChanges();

            return Ok(tActividad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TActividadExists(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            return db.TActividads.Count(e => e.IdActividad == id && e.Eliminado == false) > 0;
        }
    }
}