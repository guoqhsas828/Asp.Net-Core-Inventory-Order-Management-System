﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
  public class Invoice
  {
    public int InvoiceId { get; set; }

    [Display(Name = "Invoice Number")]
    [MaxLength(128)]
    public string InvoiceName { get; set; }

    [Display(Name = "Shipment")] public int ShipmentId { get; set; }
    [Display(Name = "Invoice Date")] public DateTimeOffset InvoiceDate { get; set; }
    [Display(Name = "Invoice Due Date")] public DateTimeOffset InvoiceDueDate { get; set; }
    [Display(Name = "Invoice Type")] public int InvoiceTypeId { get; set; }
  }
}
