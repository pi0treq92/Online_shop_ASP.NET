using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using twoja_manufaktura.ViewModels;

namespace twoja_manufaktura.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //returnUrl przekierowuje po zalogowaniu na poprzednią stronę na którą chcieliśmy wejsć a wymagała logowania
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //Filtr, ta akcja ma być wywoływana tylko i wyłącznie po przesłaniu żądania typu POST
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}