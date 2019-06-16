using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreManager.Models;

namespace StoreManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<StoreManager.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<StoreManager.Models.Bill> Bill { get; set; }

        public DbSet<StoreManager.Models.BillType> BillType { get; set; }

        public DbSet<StoreManager.Models.Branch> Branch { get; set; }

        public DbSet<StoreManager.Models.CashBank> CashBank { get; set; }

        public DbSet<StoreManager.Models.Currency> Currency { get; set; }

        public DbSet<StoreManager.Models.Customer> Customer { get; set; }

        public DbSet<StoreManager.Models.CustomerType> CustomerType { get; set; }

        public DbSet<StoreManager.Models.GoodsReceivedNote> GoodsReceivedNote { get; set; }

        public DbSet<StoreManager.Models.Invoice> Invoice { get; set; }

        public DbSet<StoreManager.Models.InvoiceType> InvoiceType { get; set; }

        public DbSet<StoreManager.Models.NumberSequence> NumberSequence { get; set; }

        public DbSet<StoreManager.Models.PaymentReceive> PaymentReceive { get; set; }

        public DbSet<StoreManager.Models.PaymentType> PaymentType { get; set; }

        public DbSet<StoreManager.Models.PaymentVoucher> PaymentVoucher { get; set; }

        public DbSet<StoreManager.Models.Product> Product { get; set; }

        public DbSet<StoreManager.Models.ProductType> ProductType { get; set; }

        public DbSet<StoreManager.Models.PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<StoreManager.Models.PurchaseOrderLine> PurchaseOrderLine { get; set; }

        public DbSet<StoreManager.Models.PurchaseType> PurchaseType { get; set; }

        public DbSet<StoreManager.Models.SalesOrder> SalesOrder { get; set; }

        public DbSet<StoreManager.Models.SalesOrderLine> SalesOrderLine { get; set; }

        public DbSet<StoreManager.Models.SalesType> SalesType { get; set; }

        public DbSet<StoreManager.Models.Shipment> Shipment { get; set; }

        public DbSet<StoreManager.Models.ShipmentType> ShipmentType { get; set; }

        public DbSet<StoreManager.Models.UnitOfMeasure> UnitOfMeasure { get; set; }

        public DbSet<StoreManager.Models.Vendor> Vendor { get; set; }

        public DbSet<StoreManager.Models.VendorType> VendorType { get; set; }

        public DbSet<StoreManager.Models.Warehouse> Warehouse { get; set; }

        public DbSet<StoreManager.Models.UserProfile> UserProfile { get; set; }
    }
}
