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
    public class AmministratoriController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Amministratori
        public ActionResult Index()
        {
            return View(db.Amministratori.ToList());
        }

        // GET: Amministratori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amministratori amministratori = db.Amministratori.Find(id);
            if (amministratori == null)
            {
                return HttpNotFound();
            }
            return View(amministratori);
        }

        // GET: Amministratori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amministratori/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdmin,Username,Pwd,Nome,Cognome,Ruolo")] Amministratori amministratori)
        {
            if (ModelState.IsValid)
            {
                db.Amministratori.Add(amministratori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amministratori);
        }

        // GET: Amministratori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amministratori amministratori = db.Amministratori.Find(id);
            if (amministratori == null)
            {
                return HttpNotFound();
            }
            return View(amministratori);
        }

        // POST: Amministratori/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdmin,Username,Pwd,Nome,Cognome,Ruolo")] Amministratori amministratori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amministratori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amministratori);
        }

        // GET: Amministratori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amministratori amministratori = db.Amministratori.Find(id);
            if (amministratori == null)
            {
                return HttpNotFound();
            }
            return View(amministratori);
        }

        // POST: Amministratori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amministratori amministratori = db.Amministratori.Find(id);
            db.Amministratori.Remove(amministratori);
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
