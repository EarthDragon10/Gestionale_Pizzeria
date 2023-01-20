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
    public class DettagliOrdineController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: DettagliOrdine
        public ActionResult Index()
        {
            var dettagliOrdine = db.DettagliOrdine.Include(d => d.Ordini).Include(d => d.Prodotti);
            return View(dettagliOrdine.ToList());
        }

        // GET in PartialView
        public ActionResult PartialViewSingoloProdotto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodotti prodotti = db.Prodotti.Find(id);
            TempData["Prodotto"] = prodotti;
            if (prodotti == null)
            {
                return HttpNotFound();
            }
            return View(prodotti);
        }

        // GET: DettagliOrdine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DettagliOrdine dettagliOrdine = db.DettagliOrdine.Find(id);
            if (dettagliOrdine == null)
            {
                return HttpNotFound();
            }
            return View(dettagliOrdine);
        }

        // GET: DettagliOrdine/Create
        public ActionResult Create()
        {
            //ViewBag.IdDettaglioOrdine = new SelectList(db.Ordini, "IdOrdine", "StatoOrdine");
            //ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "Nome");
            return View();
        }

        // POST: DettagliOrdine/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="quantita,nota")] DettagliOrdine dettagliOrdine)
        {


            dettagliOrdine.Prodotti = TempData["Prodotto"] as Prodotti;
            TempData["dettagliOrdine"] = dettagliOrdine;
            //if (ModelState.IsValid)
            //{
            //    db.DettagliOrdine.Add(dettagliOrdine);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.IdDettaglioOrdine = new SelectList(db.Ordini, "IdOrdine", "StatoOrdine", dettagliOrdine.IdDettaglioOrdine);
            //ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "Nome", dettagliOrdine.IdProdotto);
            return RedirectToAction("Create", "Ordini");
        }

        // GET: DettagliOrdine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DettagliOrdine dettagliOrdine = db.DettagliOrdine.Find(id);
            if (dettagliOrdine == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDettaglioOrdine = new SelectList(db.Ordini, "IdOrdine", "StatoOrdine", dettagliOrdine.IdDettaglioOrdine);
            ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "Nome", dettagliOrdine.IdProdotto);
            return View(dettagliOrdine);
        }

        // POST: DettagliOrdine/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDettaglioOrdine,quantita,nota,IdProdotto,IdOrdine")] DettagliOrdine dettagliOrdine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dettagliOrdine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDettaglioOrdine = new SelectList(db.Ordini, "IdOrdine", "StatoOrdine", dettagliOrdine.IdDettaglioOrdine);
            ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "Nome", dettagliOrdine.IdProdotto);
            return View(dettagliOrdine);
        }

        // GET: DettagliOrdine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DettagliOrdine dettagliOrdine = db.DettagliOrdine.Find(id);
            if (dettagliOrdine == null)
            {
                return HttpNotFound();
            }
            return View(dettagliOrdine);
        }

        // POST: DettagliOrdine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DettagliOrdine dettagliOrdine = db.DettagliOrdine.Find(id);
            db.DettagliOrdine.Remove(dettagliOrdine);
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
