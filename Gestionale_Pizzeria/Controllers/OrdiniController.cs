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
    public class OrdiniController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Ordini
        public ActionResult Index()
        {
            var ordini = db.Ordini.Include(o => o.DettagliOrdine).Include(o => o.Utenti);
            return View(ordini.ToList());
        }

        // GET: Ordini/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            return View(ordini);
        }

        // GET: Ordini/Create
        public ActionResult Create()
        {
            var data = TempData["dettagliOrdine"];
            ViewBag.IdOrdine = new SelectList(db.DettagliOrdine, "IdDettaglioOrdine", "nota");
            ViewBag.IdOrdine = new SelectList(db.Utenti, "IdUtente", "Username");
            return View();
        }

        // POST: Ordini/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOrdine,DataOrdine,Importo,StatoOrdine,Confermato,Evaso,IdDettaglioOrdine,IdUtente")] Ordini ordini)
        {
            if (ModelState.IsValid)
            {
                DettagliOrdine data = TempData["dettagliOrdine"] as DettagliOrdine;
                db.Ordini.Add(ordini);
                db.SaveChanges();
                DettagliOrdine dettagli = new DettagliOrdine();
                dettagli.IdOrdine = ordini.IdOrdine;
                dettagli.nota = data.nota;
                dettagli.quantita = data.quantita;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdOrdine = new SelectList(db.DettagliOrdine, "IdDettaglioOrdine", "nota", ordini.IdOrdine);
            ViewBag.IdOrdine = new SelectList(db.Utenti, "IdUtente", "Username", ordini.IdOrdine);
            return View(ordini);
        }

        // GET: Ordini/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdOrdine = new SelectList(db.DettagliOrdine, "IdDettaglioOrdine", "nota", ordini.IdOrdine);
            ViewBag.IdOrdine = new SelectList(db.Utenti, "IdUtente", "Username", ordini.IdOrdine);
            return View(ordini);
        }

        // POST: Ordini/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrdine,DataOrdine,Importo,StatoOrdine,Confermato,Evaso,IdDettaglioOrdine,IdUtente")] Ordini ordini)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdOrdine = new SelectList(db.DettagliOrdine, "IdDettaglioOrdine", "nota", ordini.IdOrdine);
            ViewBag.IdOrdine = new SelectList(db.Utenti, "IdUtente", "Username", ordini.IdOrdine);
            return View(ordini);
        }

        // GET: Ordini/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            return View(ordini);
        }

        // POST: Ordini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordini ordini = db.Ordini.Find(id);
            db.Ordini.Remove(ordini);
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
