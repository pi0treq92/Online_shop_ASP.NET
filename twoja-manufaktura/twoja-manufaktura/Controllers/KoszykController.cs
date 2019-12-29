using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using twoja_manufaktura.DAL;
using twoja_manufaktura.Infrastructure;
using twoja_manufaktura.Models;
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
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public async Task<ActionResult> Checkout()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var order = new Order
                {
                    Name = user.UserData.FirstName,
                    LastName = user.UserData.LastName,
                    Address = user.UserData.Address,
                    Code = user.UserData.Code,
                    City = user.UserData.City,
                    Email = user.UserData.Email,
                    PhoneNumber = user.UserData.PhoneNumber
                };
                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout", "Koszyk") });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Checkout(Order details)
        {
            if (ModelState.IsValid)
            {
                //relacja do bazy danej
                var userId = User.Identity.GetUserId();
                var order = koszykManager.UtworzZamowienie(details, userId);
                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);
                koszykManager.PustyKoszyk();
                return RedirectToAction("PotwierdzenieZamowienia");
            }
            else
            {
                return View(details);
            }
        }
        public ActionResult PotwierdzenieZamowienia()
        {
            return View();
        }
    }
}