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
    [RoutePrefix("api/PlanObBoarding")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TPlanOnBoardingsController : ApiController
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: api/TPlanOnBoardings
        [Route("listar")]
        [HttpGet]
        [ResponseType(typeof(List<TPlanOnBoarding>))]
        public IHttpActionResult GetTPlanOnBoardings()
        {
            try
            {
                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                var result = db.VCuadranteEmpleadoes.ToList();
                               return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex.GetBaseException());
            }

        }

        // GET: api/TPlanOnBoardings/5
        [ResponseType(typeof(TPlanOnBoarding))]
        public IHttpActionResult GetTPlanOnBoarding(int id)
        {
            TPlanOnBoarding tPlanOnBoarding = db.TPlanOnBoardings.Find(id);
            if (tPlanOnBoarding == null)
            {
                return NotFound();
            }

            return Ok(tPlanOnBoarding);
        }

        // PUT: api/TPlanOnBoardings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTPlanOnBoarding(int id, TPlanOnBoarding tPlanOnBoarding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tPlanOnBoarding.IdPlanOnBoarding)
            {
                return BadRequest();
            }

            db.Entry(tPlanOnBoarding).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TPlanOnBoardingExists(id))
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

        // POST: api/TPlanOnBoardings
        [ResponseType(typeof(TPlanOnBoarding))]
        public IHttpActionResult PostTPlanOnBoarding(TPlanOnBoarding tPlanOnBoarding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TPlanOnBoardings.Add(tPlanOnBoarding);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tPlanOnBoarding.IdPlanOnBoarding }, tPlanOnBoarding);
        }

        // DELETE: api/TPlanOnBoardings/5
        [ResponseType(typeof(TPlanOnBoarding))]
        public IHttpActionResult DeleteTPlanOnBoarding(int id)
        {
            TPlanOnBoarding tPlanOnBoarding = db.TPlanOnBoardings.Find(id);
            if (tPlanOnBoarding == null)
            {
                return NotFound();
            }

            db.TPlanOnBoardings.Remove(tPlanOnBoarding);
            db.SaveChanges();

            return Ok(tPlanOnBoarding);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TPlanOnBoardingExists(int id)
        {
            return db.TPlanOnBoardings.Count(e => e.IdPlanOnBoarding == id) > 0;
        }
    }
}