﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
  public class Product : BaseEntityModel
  {
    public int ProductId
    {
      get { return Id; }
      set { Id = value; }
    }

    [Required] public string ProductName { get; set; }
    public string ProductCode { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public string ProductImageUrl { get; set; }
    [Display(Name = "UOM")] public int UnitOfMeasureId { get; set; }
    public double DefaultBuyingPrice { get; set; } = 0.0;
    public double DefaultSellingPrice { get; set; } = 0.0;
    [Display(Name = "Branch")] public int BranchId { get; set; }
    [Display(Name = "Currency")] public int CurrencyId { get; set; }

    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
    public int CatalogBrandId { get; set; }
    public CatalogBrand CatalogBrand { get; set; }
  }
}
