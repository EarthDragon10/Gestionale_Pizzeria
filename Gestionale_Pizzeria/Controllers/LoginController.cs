using Gestionale_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Gestionale_Pizzeria.Controllers
{
    public class LoginController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Login
        public ActionResult SignIn()
        {
            ViewBag.IdRuolo = new SelectList(db.Ruoli, "IdRuoli", "TipoRuoli");
            return View();
        }

        [HttpPost]
        public ActionResult SignIn([Bind(Exclude = "Ruolo")] Utenti u) {
        
            var utente = db.Utenti.Where(date => date.Username.Equals(u.Username) && date.Pwd.Equals(u.Pwd));

            if(utente != null)
            {          
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            } else
            {
                ViewBag.Errore = "Username o Password sbagliato";
            }              
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.LoginUrl);
        }

    }
}