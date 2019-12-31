using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using twoja_manufaktura.Migrations;
using twoja_manufaktura.Models;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            var kategorie = new List<Kategoria>
            {
                new Kategoria() {KategoriaId = 1, Name = "Kwietniki", IconFileName = "kwietnik.png"},
                new Kategoria() {KategoriaId = 2, Name = "Łapacze snow", IconFileName = "lapacz.png"},
                new Kategoria() {KategoriaId = 3, Name = "Coś tam", IconFileName = "cos.png"},

            };
            kategorie.ForEach(g => context.Kategorie.AddOrUpdate(g));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product(){ProductId=1, Name="Kwietnik duży", Description = "Kwietnik metalowy z donicą w nowoczesnym designie.\nBędzie ciekawą dekoracją zarówno do salonu, sypialni, korytarza jak również przed drzwi wejściowe budynków, restauracji, kawiarni.", KategoriaId = 1, IsBestseller=false, DateAdded = new DateTime(2019, 10, 1), PhotoFileName = "kwietnik.jpeg", Price=30 },
                new Product(){ProductId=2, Name="Kwietnik średni", Description = "Kwietnik metalowy z donicą w nowoczesnym designie.\nBędzie ciekawą dekoracją zarówno do salonu, sypialni, korytarza jak również przed drzwi wejściowe budynków, restauracji, kawiarni.", KategoriaId = 1, IsBestseller=true, DateAdded = new DateTime(2018, 11, 1), PhotoFileName = "kwietnik.jpeg", Price=20 },
                new Product(){ProductId=3, Name="Kwietnik mały", Description = "Kwietnik metalowy z donicą w nowoczesnym designie.\nBędzie ciekawą dekoracją zarówno do salonu, sypialni, korytarza jak również przed drzwi wejściowe budynków, restauracji, kawiarni.", KategoriaId = 1, IsBestseller=false, DateAdded = new DateTime(2019, 12, 1), PhotoFileName = "kwietnik.jpeg", Price=10 },
                new Product(){ProductId=4, Name="Łapacz snów mały", Description = "Ładny, mały amulet niektórych plemion Indian z Ameryki Północnej. Składa się z sieci wplecionej w okrąg wykonany ze sprężystego drewnianego pręta", KategoriaId = 2, IsBestseller=false, DateAdded = new DateTime(2018, 11, 1), PhotoFileName = "lapacz.jpeg", Price=40 },
                new Product(){ProductId=5, Name="Łapacz snów średni", Description = "Średni amulet niektórych plemion Indian z Ameryki Północnej. Składa się z sieci wplecionej w okrąg wykonany ze sprężystego drewnianego pręta", KategoriaId = 2, IsBestseller=true, DateAdded = new DateTime(2019, 12, 2), PhotoFileName = "lapacz.jpeg", Price=80 },
                new Product(){ProductId=6, Name="Łapacz snów duży", Description = "Duży amulet niektórych plemion Indian z Ameryki Północnej. Składa się z sieci wplecionej w okrąg wykonany ze sprężystego drewnianego pręta", KategoriaId = 2, IsBestseller=true, DateAdded = new DateTime(2017, 11, 3), PhotoFileName = "lapacz.jpeg", Price=120 },
                new Product(){ProductId=7, Name="Coś", Description = "Ładny", KategoriaId = 3, IsBestseller=false, DateAdded = new DateTime(2019, 12, 10), PhotoFileName = "pierwszy-obraz.jpg", Price=10 }



            };
            products.ForEach(p => context.Products.AddOrUpdate(p));
            context.SaveChanges();
        }
        public static void IdentityForApplication(StoreContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string name = "admin@admin.pl";
            const string password = "P@ssw0rd";
            const string roleName = "Admin";


            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, UserData = new UserData() };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            //var user = userManager.FindByName(name);
            //if (user == null)
            //{
            //    user = new ApplicationUser { UserName = name, Email = name };
            //    var result = userManager.Create(user, password);
            //    result = userManager.SetLockoutEnabled(user.Id, false);
            //}

            //Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}