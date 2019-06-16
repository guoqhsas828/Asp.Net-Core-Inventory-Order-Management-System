using StoreManager.Models;

namespace StoreManager.Specifications
{
    public class CatalogFilterPaginatedSpecification : BaseSpecification<Product>
    {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId)
            : base(i => (!brandId.HasValue || i.BranchId == brandId) &&
                (!typeId.HasValue || i.Barcode == typeId.ToString()))
        {
            ApplyPaging(skip, take);
        }
    }
}
