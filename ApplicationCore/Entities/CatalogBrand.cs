namespace StoreManager.Models
{
  public class CatalogBrand : BaseEntityModel
  {
    public int CatalogBrandId
    {
      get { return Id; }
      set { Id = value; }
    }

    public string Brand { get; set; }

    public string Description { get; set; }
  }
}
