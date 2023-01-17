using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestionale_Pizzeria.Models;

namespace Gestionale_Pizzeria.Controllers
{
    public class RuoliController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Ruoli
        public ActionResult Index()
        {
            return View(db.Ruoli.ToList());
        }

        // GET: Ruoli/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruoli ruoli = db.Ruoli.Find(id);
            if (ruoli == null)
            {
                return HttpNotFound();
            }
            return View(ruoli);
        }

        // GET: Ruoli/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ruoli/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRuoli,TipoRuoli")] Ruoli ruoli)
        {
            if (ModelState.IsValid)
            {
                db.Ruoli.Add(ruoli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ruoli);
        }

        // GET: Ruoli/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruoli ruoli = db.Ruoli.Find(id);
            if (ruoli == null)
            {
                return HttpNotFound();
            }
            return View(ruoli);
        }

        // POST: Ruoli/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRuoli,TipoRuoli")] Ruoli ruoli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ruoli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ruoli);
        }

        // GET: Ruoli/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruoli ruoli = db.Ruoli.Find(id);
            if (ruoli == null)
            {
                return HttpNotFound();
            }
            return View(ruoli);
        }

        // POST: Ruoli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ruoli ruoli = db.Ruoli.Find(id);
            db.Ruoli.Remove(ruoli);
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
