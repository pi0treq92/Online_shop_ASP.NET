using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using twoja_manufaktura.Migrations;
using twoja_manufaktura.Models;
using System.Data.Entity.Migrations;

namespace twoja_manufaktura.DAL
{
    //w przypadku dodania klasy albo czegos innego powinna zostac usunieta baza danych
    public class StoreInitializer : MigrateDatabaseToLatestVersion<StoreContext, Configuration>
    {
        //protected override void Seed(StoreContext context)
        //{
        //    SeedStoreData(context);
        //    base.Seed(context);
        //}

        public static void SeedStoreData(StoreContext context)
        {
            var genres = new List<Genre>
            {
                new Genre() {GenreId = 1, Name = "Kwietniki", IconFileName = "kwietnik.png"},
                new Genre() {GenreId = 2, Name = "Łapacze snow", IconFileName = "lapacz.png"},
                new Genre() {GenreId = 3, Name = "Coś tam", IconFileName = "cos.png"},

            };
            genres.ForEach(g => context.Genres.AddOrUpdate(g));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product(){ProductId=1, Name="Kwietnik duży", Description = "Kwietnik metalowy z donicą w nowoczesnym designie.\nBędzie ciekawą dekoracją zarówno do salonu, sypialni, korytarza jak również przed drzwi wejściowe budynków, restauracji, kawiarni.", GenreId = 1, IsBestseller=false, DateAdded = new DateTime(2019, 10, 1), PhotoFileName = "kwietnik.jpeg", Price=30 },
                new Product(){ProductId=2, Name="Kwietnik średni", Description = "Kwietnik metalowy z donicą w nowoczesnym designie.\nBędzie ciekawą dekoracją zarówno do salonu, sypialni, korytarza jak również przed drzwi wejściowe budynków, restauracji, kawiarni.", GenreId = 1, IsBestseller=true, DateAdded = new DateTime(2018, 11, 1), PhotoFileName = "kwietnik.jpeg", Price=20 },
                new Product(){ProductId=3, Name="Kwietnik mały", Description = "Kwietnik metalowy z donicą w nowoczesnym designie.\nBędzie ciekawą dekoracją zarówno do salonu, sypialni, korytarza jak również przed drzwi wejściowe budynków, restauracji, kawiarni.", GenreId = 1, IsBestseller=false, DateAdded = new DateTime(2019, 12, 1), PhotoFileName = "kwietnik.jpeg", Price=10 },
                new Product(){ProductId=4, Name="Łapacz snów mały", Description = "Ładny, mały amulet niektórych plemion Indian z Ameryki Północnej. Składa się z sieci wplecionej w okrąg wykonany ze sprężystego drewnianego pręta", GenreId = 2, IsBestseller=false, DateAdded = new DateTime(2018, 11, 1), PhotoFileName = "lapacz.jpeg", Price=40 },
                new Product(){ProductId=5, Name="Łapacz snów średni", Description = "Średni amulet niektórych plemion Indian z Ameryki Północnej. Składa się z sieci wplecionej w okrąg wykonany ze sprężystego drewnianego pręta", GenreId = 2, IsBestseller=true, DateAdded = new DateTime(2019, 12, 2), PhotoFileName = "lapacz.jpeg", Price=80 },
                new Product(){ProductId=6, Name="Łapacz snów duży", Description = "Duży amulet niektórych plemion Indian z Ameryki Północnej. Składa się z sieci wplecionej w okrąg wykonany ze sprężystego drewnianego pręta", GenreId = 2, IsBestseller=true, DateAdded = new DateTime(2017, 11, 3), PhotoFileName = "lapacz.jpeg", Price=120 },
                new Product(){ProductId=7, Name="Coś", Description = "Ładny", GenreId = 3, IsBestseller=false, DateAdded = new DateTime(2019, 12, 10), PhotoFileName = "pierwszy-obraz.jpg", Price=10 }



            };
            products.ForEach(p => context.Products.AddOrUpdate(p));
            context.SaveChanges();
        }
    }
}