using StoreManager.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreManager.Models;

namespace StoreManager.Data
{
  public class CatalogContextSeed
  {
    public static async Task SeedAsync(ApplicationDbContext catalogContext,
      ILoggerFactory loggerFactory, int? retry = 0)
    {
      int retryForAvailability = retry.Value;
      try
      {
        // TODO: Only run this if using a real database
        catalogContext.Database.Migrate();

        if (!catalogContext.CatalogBrands.Any())
        {
          catalogContext.CatalogBrands.AddRange(
            GetPreconfiguredCatalogBrands());

          await catalogContext.SaveChangesAsync();
        }

        if (!catalogContext.ProductType.Any())
        {
          catalogContext.ProductType.AddRange(
            GetPreconfiguredCatalogTypes());

          await catalogContext.SaveChangesAsync();
        }

        if (!catalogContext.Product.Any())
        {
          catalogContext.Product.AddRange(
            GetPreconfiguredItems());

          await catalogContext.SaveChangesAsync();
        }
      }
      catch (Exception ex)
      {
        if (retryForAvailability < 10)
        {
          retryForAvailability++;
          var log = loggerFactory.CreateLogger<CatalogContextSeed>();
          log.LogError(ex.Message);
          await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
        }
      }
    }

    static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
    {
      return new List<CatalogBrand>()
      {
         new CatalogBrand() {Brand = "Other"},
        new CatalogBrand() {Brand = "Allison"},
        new CatalogBrand() {Brand = "Jason"},
      };
    }

    static IEnumerable<ProductType> GetPreconfiguredCatalogTypes()
    {
      return new List<ProductType>()
      {
        new ProductType() {ProductTypeName = "Other"},
        new ProductType() {ProductTypeName = "Drink"},
        new ProductType() {ProductTypeName = "Cookies"},
      };
    }

    static IEnumerable<Product> GetPreconfiguredItems()
    {
      return new List<Product>()
      {
        new Product()
        {
          ProductTypeId = 3, CatalogBrandId = 3, Description = ".NET Bot Black Sweatshirt", ProductName = "Lemonade",
          DefaultSellingPrice = 19.5, ProductImageUrl = "http://catalogbaseurltobereplaced/images/products/1.png"
        },
        new Product()
        {
          ProductTypeId = 2, CatalogBrandId = 3, Description = ".NET Black & White Mug", ProductName = "Lemonade(s)",
          DefaultSellingPrice = 8.50, ProductImageUrl = "http://catalogbaseurltobereplaced/images/products/2.png"
        },
        new Product()
        {
          ProductTypeId = 3, CatalogBrandId = 2, Description = "Prism White T-Shirt", ProductName = "MilkShake",
          DefaultSellingPrice = 12, ProductImageUrl = "http://catalogbaseurltobereplaced/images/products/3.png"
        },
      };
    }
  }
}
