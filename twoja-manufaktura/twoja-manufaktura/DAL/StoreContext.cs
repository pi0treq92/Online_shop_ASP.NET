﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using twoja_manufaktura.Models;

namespace twoja_manufaktura.DAL
{
    //StoreContext reprezentuje cala baze danych
    //Umieszczone w niej pola reprezentuja poszczególne tabele
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext")
        {

        }
        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(new StoreInitializer());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}