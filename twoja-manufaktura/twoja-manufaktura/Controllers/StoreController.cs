using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using twoja_manufaktura.DAL;

namespace twoja_manufaktura.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        StoreContext db = new StoreContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }
        public ActionResult List(string genrename)
        {
            var genre = db.Genres.Include("Products").Where(g => g.Name.ToUpper() == genrename.ToUpper()).Single();
            var products = genre.Products.ToList();
            return View(products);
        }
        [ChildActionOnly]
        public ActionResult GenresMenu()
        {
            var genres = db.Genres.ToList();
            return PartialView("_GenresMenu", genres);
        }

    }
}