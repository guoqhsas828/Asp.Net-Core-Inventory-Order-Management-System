﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreManager.Data;

namespace Microsoft.eShopWeb.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StoreManager.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("StoreManager.Models.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("BillDate");

                    b.Property<DateTimeOffset>("BillDueDate");

                    b.Property<string>("BillName")
                        .HasMaxLength(64);

                    b.Property<int>("BillTypeId");

                    b.Property<int>("GoodsReceivedNoteId");

                    b.Property<string>("VendorDONumber")
                        .HasMaxLength(900);

                    b.Property<string>("VendorInvoiceNumber")
                        .HasMaxLength(900);

                    b.HasKey("BillId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("StoreManager.Models.BillType", b =>
                {
                    b.Property<int>("BillTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BillTypeName")
                        .IsRequired()
                        .HasMaxLength(900);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.HasKey("BillTypeId");

                    b.ToTable("BillType");
                });

            modelBuilder.Entity("StoreManager.Models.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(256);

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("City")
                        .HasMaxLength(128);

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(128);

                    b.Property<int>("CurrencyId");

                    b.Property<string>("Description")
                        .HasMaxLength(512);

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<string>("Phone")
                        .HasMaxLength(32);

                    b.Property<string>("State")
                        .HasMaxLength(128);

                    b.Property<string>("ZipCode")
                        .HasMaxLength(32);

                    b.HasKey("BranchId");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("StoreManager.Models.CashBank", b =>
                {
                    b.Property<int>("CashBankId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CashBankName")
                        .HasMaxLength(64);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.HasKey("CashBankId");

                    b.ToTable("CashBank");
                });

            modelBuilder.Entity("StoreManager.Models.CatalogBrand", b =>
                {
                    b.Property<int>("CatalogBrandId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasMaxLength(128);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.HasKey("CatalogBrandId");

                    b.ToTable("CatalogBrand");
                });

            modelBuilder.Entity("StoreManager.Models.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.HasKey("CurrencyId");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("StoreManager.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(256);

                    b.Property<string>("City")
                        .HasMaxLength(128);

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(128);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("CustomerTypeId");

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<string>("Phone")
                        .HasMaxLength(32);

                    b.Property<string>("State")
                        .HasMaxLength(128);

                    b.Property<string>("ZipCode")
                        .HasMaxLength(32);

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("StoreManager.Models.CustomerType", b =>
                {
                    b.Property<int>("CustomerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerTypeName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.HasKey("CustomerTypeId");

                    b.ToTable("CustomerType");
                });

            modelBuilder.Entity("StoreManager.Models.GoodsReceivedNote", b =>
                {
                    b.Property<int>("GoodsReceivedNoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("GRNDate");

                    b.Property<string>("GoodsReceivedNoteName")
                        .HasMaxLength(128);

                    b.Property<bool>("IsFullReceive");

                    b.Property<int>("PurchaseOrderId");

                    b.Property<string>("VendorDONumber")
                        .HasMaxLength(128);

                    b.Property<string>("VendorInvoiceNumber")
                        .HasMaxLength(128);

                    b.Property<int>("WarehouseId");

                    b.HasKey("GoodsReceivedNoteId");

                    b.ToTable("GoodsReceivedNote");
                });

            modelBuilder.Entity("StoreManager.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("InvoiceDate");

                    b.Property<DateTimeOffset>("InvoiceDueDate");

                    b.Property<string>("InvoiceName")
                        .HasMaxLength(128);

                    b.Property<int>("InvoiceTypeId");

                    b.Property<int>("ShipmentId");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("StoreManager.Models.InvoiceType", b =>
                {
                    b.Property<int>("InvoiceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("InvoiceTypeName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("InvoiceTypeId");

                    b.ToTable("InvoiceType");
                });

            modelBuilder.Entity("StoreManager.Models.NumberSequence", b =>
                {
                    b.Property<int>("NumberSequenceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LastNumber");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<string>("NumberSequenceName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("NumberSequenceId");

                    b.ToTable("NumberSequence");
                });

            modelBuilder.Entity("StoreManager.Models.PaymentReceive", b =>
                {
                    b.Property<int>("PaymentReceiveId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceId");

                    b.Property<bool>("IsFullPayment");

                    b.Property<double>("PaymentAmount");

                    b.Property<DateTimeOffset>("PaymentDate");

                    b.Property<string>("PaymentReceiveName")
                        .HasMaxLength(128);

                    b.Property<int>("PaymentTypeId");

                    b.HasKey("PaymentReceiveId");

                    b.ToTable("PaymentReceive");
                });

            modelBuilder.Entity("StoreManager.Models.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("PaymentTypeId");

                    b.ToTable("PaymentType");
                });

            modelBuilder.Entity("StoreManager.Models.PaymentVoucher", b =>
                {
                    b.Property<int>("PaymentVoucherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillId");

                    b.Property<int>("CashBankId");

                    b.Property<bool>("IsFullPayment");

                    b.Property<double>("PaymentAmount");

                    b.Property<DateTimeOffset>("PaymentDate");

                    b.Property<int>("PaymentTypeId");

                    b.Property<string>("PaymentVoucherName")
                        .HasMaxLength(128);

                    b.HasKey("PaymentVoucherId");

                    b.ToTable("PaymentVoucher");
                });

            modelBuilder.Entity("StoreManager.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .HasMaxLength(128);

                    b.Property<int>("BranchId");

                    b.Property<int>("CatalogBrandId");

                    b.Property<int>("CurrencyId");

                    b.Property<double>("DefaultBuyingPrice");

                    b.Property<double>("DefaultSellingPrice");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("ProductCode")
                        .HasMaxLength(128);

                    b.Property<string>("ProductImageUrl")
                        .HasMaxLength(1024);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("ProductTypeId");

                    b.Property<int>("UnitOfMeasureId");

                    b.HasKey("ProductId");

                    b.HasIndex("CatalogBrandId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("StoreManager.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("ProductTypeName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("StoreManager.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("PurchaseOrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<int>("BranchId");

                    b.Property<int>("CurrencyId");

                    b.Property<DateTimeOffset>("DeliveryDate");

                    b.Property<double>("Discount");

                    b.Property<double>("Freight");

                    b.Property<DateTimeOffset>("OrderDate");

                    b.Property<string>("PurchaseOrderName")
                        .HasMaxLength(128);

                    b.Property<int>("PurchaseTypeId");

                    b.Property<string>("Remarks");

                    b.Property<double>("SubTotal");

                    b.Property<double>("Tax");

                    b.Property<double>("Total");

                    b.Property<int>("VendorId");

                    b.HasKey("PurchaseOrderId");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("StoreManager.Models.PurchaseOrderLine", b =>
                {
                    b.Property<int>("PurchaseOrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<double>("DiscountAmount");

                    b.Property<double>("DiscountPercentage");

                    b.Property<double>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("PurchaseOrderId");

                    b.Property<double>("Quantity");

                    b.Property<double>("SubTotal");

                    b.Property<double>("TaxAmount");

                    b.Property<double>("TaxPercentage");

                    b.Property<double>("Total");

                    b.HasKey("PurchaseOrderLineId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseOrderLine");
                });

            modelBuilder.Entity("StoreManager.Models.PurchaseType", b =>
                {
                    b.Property<int>("PurchaseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("PurchaseTypeName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("PurchaseTypeId");

                    b.ToTable("PurchaseType");
                });

            modelBuilder.Entity("StoreManager.Models.SalesOrder", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<int>("BranchId");

                    b.Property<int>("CurrencyId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("CustomerRefNumber")
                        .HasMaxLength(128);

                    b.Property<DateTimeOffset>("DeliveryDate");

                    b.Property<double>("Discount");

                    b.Property<double>("Freight");

                    b.Property<DateTimeOffset>("OrderDate");

                    b.Property<string>("Remarks")
                        .HasMaxLength(1024);

                    b.Property<string>("SalesOrderName")
                        .HasMaxLength(128);

                    b.Property<int>("SalesTypeId");

                    b.Property<double>("SubTotal");

                    b.Property<double>("Tax");

                    b.Property<double>("Total");

                    b.HasKey("SalesOrderId");

                    b.ToTable("SalesOrder");
                });

            modelBuilder.Entity("StoreManager.Models.SalesOrderLine", b =>
                {
                    b.Property<int>("SalesOrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<double>("DiscountAmount");

                    b.Property<double>("DiscountPercentage");

                    b.Property<double>("Price");

                    b.Property<int>("ProductId");

                    b.Property<double>("Quantity");

                    b.Property<int>("SalesOrderId");

                    b.Property<double>("SubTotal");

                    b.Property<double>("TaxAmount");

                    b.Property<double>("TaxPercentage");

                    b.Property<double>("Total");

                    b.HasKey("SalesOrderLineId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SalesOrderId");

                    b.ToTable("SalesOrderLine");
                });

            modelBuilder.Entity("StoreManager.Models.SalesType", b =>
                {
                    b.Property<int>("SalesTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("SalesTypeName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("SalesTypeId");

                    b.ToTable("SalesType");
                });

            modelBuilder.Entity("StoreManager.Models.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsFullShipment");

                    b.Property<int>("SalesOrderId");

                    b.Property<DateTimeOffset>("ShipmentDate");

                    b.Property<string>("ShipmentName")
                        .HasMaxLength(128);

                    b.Property<int>("ShipmentTypeId");

                    b.Property<int>("WarehouseId");

                    b.HasKey("ShipmentId");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("StoreManager.Models.ShipmentType", b =>
                {
                    b.Property<int>("ShipmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("ShipmentTypeName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("ShipmentTypeId");

                    b.ToTable("ShipmentType");
                });

            modelBuilder.Entity("StoreManager.Models.UnitOfMeasure", b =>
                {
                    b.Property<int>("UnitOfMeasureId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("UnitOfMeasureName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("UnitOfMeasureId");

                    b.ToTable("UnitOfMeasure");
                });

            modelBuilder.Entity("StoreManager.Models.UserProfile", b =>
                {
                    b.Property<int>("UserProfileId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AchievedLevel");

                    b.Property<double>("AchievedPoints");

                    b.Property<string>("ApplicationUserId")
                        .HasMaxLength(900);

                    b.Property<string>("ConfirmPassword")
                        .HasMaxLength(128);

                    b.Property<int>("Continent");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<int>("ExperienceLevel");

                    b.Property<string>("FirstName")
                        .HasMaxLength(128);

                    b.Property<string>("LastName")
                        .HasMaxLength(128);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<DateTime>("LatestLogin");

                    b.Property<string>("OldPassword")
                        .HasMaxLength(128);

                    b.Property<string>("Password")
                        .HasMaxLength(128);

                    b.Property<string>("ProfilePicture")
                        .HasMaxLength(1024);

                    b.Property<int>("UserStatus");

                    b.HasKey("UserProfileId");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("StoreManager.Models.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(256);

                    b.Property<string>("City")
                        .HasMaxLength(128);

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(128);

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<string>("Phone")
                        .HasMaxLength(32);

                    b.Property<string>("State")
                        .HasMaxLength(128);

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("VendorTypeId");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(32);

                    b.HasKey("VendorId");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("StoreManager.Models.VendorType", b =>
                {
                    b.Property<int>("VendorTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("VendorTypeName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("VendorTypeId");

                    b.ToTable("VendorType");
                });

            modelBuilder.Entity("StoreManager.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StoreManager.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StoreManager.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StoreManager.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StoreManager.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StoreManager.Models.Product", b =>
                {
                    b.HasOne("StoreManager.Models.CatalogBrand", "CatalogBrand")
                        .WithMany()
                        .HasForeignKey("CatalogBrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StoreManager.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StoreManager.Models.PurchaseOrderLine", b =>
                {
                    b.HasOne("StoreManager.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany("PurchaseOrderLines")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StoreManager.Models.SalesOrderLine", b =>
                {
                    b.HasOne("StoreManager.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StoreManager.Models.SalesOrder", "SalesOrder")
                        .WithMany("SalesOrderLines")
                        .HasForeignKey("SalesOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
