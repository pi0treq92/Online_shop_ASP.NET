using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using twoja_manufaktura.DAL;
using twoja_manufaktura.Infrastructure;
using twoja_manufaktura.ViewModels;

namespace twoja_manufaktura.Controllers
{
    public class KoszykController : Controller
    {
        private KoszykManager koszykManager;
        private ISessionManager sessionManager { get; set; }
        private StoreContext db = new StoreContext();
        public KoszykController()
        {
            this.sessionManager = new SessionManager();
            this.koszykManager = new KoszykManager(this.sessionManager, this.db);
        }
        // GET: Koszyk
        public ActionResult Index()
        {
            //pobiera aktualny stan koszyka w sesji
            var koszykItems = koszykManager.GetKoszyk();
            var koszykTotalPrice = koszykManager.GetTotalPrice();
            KoszykViewModel koszykVM = new KoszykViewModel()
            {
                KoszykItems = koszykItems,
                TotalPrice = koszykTotalPrice
            };
            return View(koszykVM);
        }
        public ActionResult DodajDoKoszyka(int id)
        {
            koszykManager.DodajDoKoszyka(id);
            //kiedy użytkownik wywoła dodajdokoszyka, wywoła się index
            return RedirectToAction("Index");
        }
        public int LiczbaRzeczyWKoszyku()
        {
            return koszykManager.GetKoszykItemsCount();
        }
        public ActionResult UsunZKoszyka(int productId)
        {
            KoszykManager koszykManager = new KoszykManager(this.sessionManager, this.db);

        int itemCount = koszykManager.UsunZKoszyka(productId);
        int koszykItemsCount = koszykManager.GetKoszykItemsCount();
        decimal koszykTotalPrice = koszykManager.GetTotalPrice();

        // Zwraca JSON do skryptu JavaScript
        var result = new KoszykRemoveViewModel
        {
            RemovedItemId = productId,
            RemovedItemCount = itemCount,
            KoszykTotalPrice = koszykTotalPrice,
            KoszykItemsCount = koszykItemsCount
        };

            return Json(result);
    }
    }
}