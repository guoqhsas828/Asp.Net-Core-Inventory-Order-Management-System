using StoreManager.Models;

namespace StoreManager.Specifications
{

    public class CatalogFilterSpecification : BaseSpecification<Product>
    {
        public CatalogFilterSpecification(int? brandId, int? typeId)
            : base(i => (!brandId.HasValue || i.BranchId == brandId) &&
                (!typeId.HasValue || i.Barcode == typeId.ToString()))
        {
        }
    }
}
