using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
  public class ProductType : BaseEntityModel
  {
    public int ProductTypeId
    {
      get { return Id; }
      set { Id = value; }
    }

    [Required] public string ProductTypeName { get; set; }
    public string Description { get; set; }
  }
}
