using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebVehiculos.Models;
using WebVehiculos.Utilidades;

namespace WebVehiculos.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario model)
        {
           
            if (Membership.ValidateUser(model.Login, model.Password))
            {
                
                TempData["horaLogin"] = DateTime.Now;

                FormsAuthentication.RedirectFromLoginPage(model.Login,false);
                return null;

            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");

        }

    }
}