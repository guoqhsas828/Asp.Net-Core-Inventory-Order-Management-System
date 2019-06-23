using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.Infrastructure.Identity;
using StoreManager.Models;

namespace Microsoft.eShopWeb.Infrastructure.Data
{

  public class CatalogContext : DbContext
  {
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Basket>(ConfigureBasket);
      builder.Entity<Address>(ConfigureAddress);
      builder.Entity<BasketItem>(ConfigureBasketItem);
      //builder.Entity<Product>(ConfigurateCatalogProduct);
    }

    private void ConfigureBasketItem(EntityTypeBuilder<BasketItem> builder)
    {
      builder.Property(bi => bi.UnitPrice)
        .IsRequired(true)
        .HasColumnType("decimal(18,2)");
    }

    //private void ConfigurateCatalogProduct(EntityTypeBuilder<Product> builder)
    //{
    //  builder.Property(cio => cio.ProductName)
    //      .HasMaxLength(50)
    //      .IsRequired();
    //}

    private void ConfigureAddress(EntityTypeBuilder<Address> builder)
    {
      builder.Property(a => a.ZipCode)
        .HasMaxLength(18)
        .IsRequired();

      builder.Property(a => a.Street)
        .HasMaxLength(180)
        .IsRequired();

      builder.Property(a => a.State)
        .HasMaxLength(60);

      builder.Property(a => a.Country)
        .HasMaxLength(90)
        .IsRequired();

      builder.Property(a => a.City)
        .HasMaxLength(100)
        .IsRequired();
    }

    private void ConfigureBasket(EntityTypeBuilder<Basket> builder)
    {
      var navigation = builder.Metadata.FindNavigation(nameof(Basket.Items));

      navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

  }
}
