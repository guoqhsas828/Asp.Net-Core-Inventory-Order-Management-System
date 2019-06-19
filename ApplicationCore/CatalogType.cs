using StoreManager.Models;

namespace Microsoft.eShopWeb.Infrastructure.Identity
{
    public class CatalogType : BaseEntity
    {
      public int CatalogTypeId
      {
        get { return Id; }
        set { Id = value; }
      }
      public string Type { get; set; }
    }
}
