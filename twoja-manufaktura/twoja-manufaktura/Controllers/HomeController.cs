using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using twoja_manufaktura.DAL;
using twoja_manufaktura.Models;
using twoja_manufaktura.ViewModels;

namespace twoja_manufaktura.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();
        // GET: Home
        public ActionResult Index()
        {
            var genres = db.Genres.ToList();
            var newArrivals = db.Products.Where(a => !a.IsHidden).OrderByDescending(a => a.DateAdded).Take(3).ToList();
            var bestsellers = db.Products.Where(a => a.IsBestseller && !a.IsHidden).Take(3).ToList();
            var vm = new HomeViewModel()
            {
                Bestsellers = bestsellers,
                Genres = genres,
                NewArrivals = newArrivals
            };

            return View(vm);
        }
        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }
    }
}