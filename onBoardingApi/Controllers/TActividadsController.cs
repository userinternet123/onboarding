using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using onBoardingApi.Models;

namespace onBoardingApi.Controllers
{
    public class TActividadsController : Controller
    {
        private dbOnboardingEntities db = new dbOnboardingEntities();

        // GET: TActividads
        public ActionResult Index()
        {
            return View(db.TActividads.ToList());
        }

        // GET: TActividads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TActividad tActividad = db.TActividads.Find(id);
            if (tActividad == null)
            {
                return HttpNotFound();
            }
            return View(tActividad);
        }

        // GET: TActividads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TActividads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdActividad,NombreActividad,DescripcionActividad,Peso,DiasEvaluar")] TActividad tActividad)
        {
            if (ModelState.IsValid)
            {
                db.TActividads.Add(tActividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tActividad);
        }

        // GET: TActividads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TActividad tActividad = db.TActividads.Find(id);
            if (tActividad == null)
            {
                return HttpNotFound();
            }
            return View(tActividad);
        }

        // POST: TActividads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdActividad,NombreActividad,DescripcionActividad,Peso,DiasEvaluar")] TActividad tActividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tActividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tActividad);
        }

        // GET: TActividads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TActividad tActividad = db.TActividads.Find(id);
            if (tActividad == null)
            {
                return HttpNotFound();
            }
            return View(tActividad);
        }

        // POST: TActividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TActividad tActividad = db.TActividads.Find(id);
            db.TActividads.Remove(tActividad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
