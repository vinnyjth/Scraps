using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Scraps.Models;
using Scraps.Data;

namespace Scraps.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            db.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }
            if (!db.Categories.Any())
            {
                db.Categories.AddRange(
                    new Category
                    {
                        Name = "Bath Soaps"
                    },
                    new Category
                    {
                        Name = "Bath Bombs"
                    }
                    );
            }
            db.SaveChanges();
            if (!db.Products.Any())
            {
                db.Products.AddRange(
                    new Product
                    {
                        Name = "Lemongrass Thing",
                        Type = "Bath Soap",
                        CategoryId = db.Categories.FirstOrDefault(c => c.Name == "Bath Soaps").Id,
                        Quantity = 11,
                        Sku = 123456,
                        LotNumber = 123456,
                        Price = 2.5m,
                        ProductionCost = 1.5m
                    }
                );
            }
            db.SaveChanges();
        }

    }
}


