using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using twoja_manufaktura.DAL;
using twoja_manufaktura.Models;

namespace twoja_manufaktura.Infrastructure
{
    public class KoszykManager
    {
        private StoreContext db;
        private ISessionManager session;
        public const string SessionKey = "CartData";
        public KoszykManager(ISessionManager session, StoreContext db)
        {
            this.session = session;
            this.db = db;
        }
        public void DodajDoKoszyka(int productid)
        {
            var koszyk = this.GetKoszyk();

            var koszykItem = koszyk.Find(c => c.Product.ProductId == productid);

            if (koszykItem != null)
                koszykItem.Quantity++;
            else
            {
                // Wyszukiwanie i dodawanie produktu do koszyka
                var productToAdd = db.Products.Where(a => a.ProductId == productid).SingleOrDefault();
                if (productToAdd != null)
                {
                    var newKoszykItem = new ItemKoszyk()
                    {
                        Product = productToAdd,
                        Quantity = 1,
                        TotalPrice = productToAdd.Price
                    };

                    koszyk.Add(newKoszykItem);
                }
            }

            session.Set(SessionKey, koszyk);
        }

        public int UsunZKoszyka(int productid)
        {
            var koszyk = this.GetKoszyk();

            var koszykItem = koszyk.Find(c => c.Product.ProductId == productid);

            if (koszykItem != null)
            {
                if (koszykItem.Quantity > 1)
                {
                    koszykItem.Quantity--;
                    return koszykItem.Quantity;
                }
                else
                    koszyk.Remove(koszykItem);
            }

            // Zwraca ilość usuniętych itemów z obecnego koszyka
            return 0;
        }


        public List<ItemKoszyk> GetKoszyk()
        {
            //Metoda zwraca istniejącą listę z koszyka lub instancjonuje nową 
            List<ItemKoszyk> cart;

            if (session.Get<List<ItemKoszyk>>(SessionKey) == null)
            {
                cart = new List<ItemKoszyk>();
            }
            else
            {
                cart = session.Get<List<ItemKoszyk>>(SessionKey) as List<ItemKoszyk>;
            }

            return cart;
        }

        public decimal GetTotalPrice()
        {
            var koszyk = this.GetKoszyk();
            return koszyk.Sum(c => (c.Quantity * c.Product.Price));
        }

        public int GetKoszykItemsCount()
        {
            //zlicza łączną ilość elementów w koszyku
            var koszyk = this.GetKoszyk();
            int count = koszyk.Sum(c => c.Quantity);

            return count;
        }

        public Order UtworzZamowienie(Order newOrder, string userId)
        {
            var koszyk = this.GetKoszyk();

            newOrder.DateCreated = DateTime.Now;
            newOrder.UserId = userId;

            this.db.Orders.Add(newOrder);

            if (newOrder.OrderItems == null)
                newOrder.OrderItems = new List<OrderItem>();

            decimal koszykTotal = 0;

            foreach (var koszykItem in koszyk)
            {
                var newOrderItem = new OrderItem()
                {
                    ProductId = koszykItem.Product.ProductId,
                    Quantity = koszykItem.Quantity,
                    UnitPrice = koszykItem.Product.Price
                };

                koszykTotal += (koszykItem.Quantity * koszykItem.Product.Price);

                newOrder.OrderItems.Add(newOrderItem);
            }

            newOrder.TotalPrice = koszykTotal;

            this.db.SaveChanges();

            return newOrder;
        }

        public void PustyKoszyk()
        {
            session.Set<List<ItemKoszyk>>(SessionKey, null);
        }
    }
}