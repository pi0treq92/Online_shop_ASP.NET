﻿using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using twoja_manufaktura.DAL;
using twoja_manufaktura.Models;

namespace twoja_manufaktura.Infrastructure
{
    public class ProductListDynamiNodeProvider : DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Kategoria p in db.Kategorie)
            {
                DynamicNode node1 = new DynamicNode();
                node1.Title = p.Name;
                node1.Key = "Kategoria_" + p.KategoriaId;
                node1.RouteValues.Add("genrename", p.Name);
                returnValue.Add(node1);


            }
            return returnValue;
        }
    }
}