using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
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
        public ActionResult List(string genrename, string searchQuery = null)
        {

            var genre = db.Genres.Include("Products").Where(g => g.Name.ToUpper() == genrename.ToUpper()).Single();
            var products = genre.Products.Where(p => searchQuery==null ||
                            p.Name.ToLower().Contains(searchQuery.ToLower()) ||
                            p.Description.ToLower().Contains(searchQuery.ToLower()) 
                            && !p.IsHidden);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductList", products);
            }
            return View(products);
        }
        [ChildActionOnly]
        [OutputCache(Duration =  3600*24*7)]
        //Cachowanie pierwszy argument jest domyślny, można zmienić przechowywanie na serwer albo klienta,
        //Drugi argument to czas przechowywania w sekundach
        public ActionResult GenresMenu()
        {
            var genres = db.Genres.ToList();
            return PartialView("_GenresMenu", genres);
        }

        public ActionResult ProductsSuggestions(string term)
        {
            //zwraca maks. 5 wyników pasujących w filtrowaniu w formacie json zgodnie z doc JQueryUI
            var products = this.db.Products.Where(p => p.Name.ToLower().Contains(term.ToLower()) && !p.IsHidden).Take(5).Select(p => new { label = p.Name });
            return Json(products, JsonRequestBehavior.AllowGet);
        }

    }
}