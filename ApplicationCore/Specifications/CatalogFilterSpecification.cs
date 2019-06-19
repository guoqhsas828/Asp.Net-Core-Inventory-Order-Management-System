using Microsoft.eShopWeb.ApplicationCore.Entities;
using StoreManager.Models;

namespace StoreManager.Specifications
{

    public class CatalogFilterSpecification : BaseSpecification<Product>
    {
        public CatalogFilterSpecification(int? brandId, int? typeId)
            : base(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.ProductTypeId == typeId))
        {
        }
    }
}
