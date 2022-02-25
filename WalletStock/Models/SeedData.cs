using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WalletStock.Data;
using System;
using System.Linq;

namespace WalletStock.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WalletStockContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WalletStockContext>>()))
            {
                // Look for any movies.
                if (context.Wallets.Any())
                {
                    return;   // DB has been seeded
                }

                context.Wallets.AddRange(
                    new Wallets
                    {
                        Company = "The Bi-fold",
                        Color = "Brown",
                        Leather = "Yes",
                        Shape = "Basic",
                        Price = 7.9M,
                        Rating = 4
                    },

                    new Wallets
                    {
                        Company = "Tri-fold",
                        Color = "Dark-brown",
                        Leather = "Yes",
                        Shape = "Two flaps",
                        Price = 10.9M,
                        Rating = 3
                    },
                     new Wallets
                     {
                         Company = "Bellroy",
                         Color = "Black",
                         Leather = "pure",
                         Shape = "Flat square",
                         Price = 5.3M,
                         Rating = 5
                     },

                     new Wallets
                     {
                         Company = "Harber London",
                         Color = "Light-Brown",
                         Leather = "Premium",
                         Shape = "Rectangle",
                         Price = 9.9M,
                         Rating = 4
                     },
                      new Wallets
                      {
                          Company = "Vaultskin",
                          Color = "Brown",
                          Leather = "Premium",
                          Shape = "Rectangle",
                          Price = 8.9M,
                          Rating = 4
                      },
                      new Wallets
                      {
                          Company = "The Ridge",
                          Color = "Brown",
                          Leather = "Premium-Classic",
                          Shape = "Square",
                          Price = 15.9M,
                          Rating = 3
                      },
                       new Wallets
                       {
                           Company = "Bellroy Hide & Seek",
                           Color = "Drak-Brown",
                           Leather = "Classic",
                           Shape = "Square",
                           Price = 12.9M,
                           Rating = 2

                       },
                       new Wallets
                       {
                           Company = "Bottega Veneta",
                           Color = "Red",
                           Leather = "Classic",
                           Shape = "Square",
                           Price = 18.9M,
                           Rating = 4
                       },
                       new Wallets
                       {
                           Company = "Tom Ford",
                           Color = "Black",
                           Leather = "Classic-Brand",
                           Shape = "Square",
                           Price = 6.9M,
                           Rating = 5
                       },
                       new Wallets
                       {
                           Company = "Fossil",
                           Color = "Black",
                           Leather = "Classic-Brand",
                           Shape = "Square",
                           Price = 31.8M,
                           Rating = 5
                       }

                );
                context.SaveChanges();
            }
        }
    }
}