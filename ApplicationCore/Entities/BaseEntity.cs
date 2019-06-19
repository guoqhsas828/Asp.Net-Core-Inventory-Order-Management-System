using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.Models
{

  // This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
  // Using non-generic integer types for simplicity and to ease caching logic

  public class BaseEntity
  {
    [NotMapped]
    public int Id { get; set; }

  }

}