using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using twoja_manufaktura.DAL;
using twoja_manufaktura.Models;

namespace twoja_manufaktura.Infrastructure
{
    public class ProductDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext(); 
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            foreach(Product p in db.Products)
            {
                DynamicNode node1 = new DynamicNode();
                node1.Title = p.Name;
                node1.Key = "Product_" + p.ProductId;
                node1.ParentKey = "Genre_" + p.GenreId;
                node1.RouteValues.Add("id", p.ProductId);
                returnValue.Add(node1);


            }
            return returnValue;
        }
    }
}