using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using twoja_manufaktura.DAL;

namespace twoja_manufaktura
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Ni¿ej jeden ze sposobow na inicjalizowanie danych w bazie danych
            // Inny to ustawienie w web.config oraz statyczny konstruktor w StoreContext.cs
            // Database.SetInitializer<StoreContext>(new StoreInitializer());
        }
    }
}
