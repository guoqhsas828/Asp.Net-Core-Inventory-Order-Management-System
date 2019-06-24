using System;
using System.ComponentModel.DataAnnotations;
using StoreManager.Models;

namespace WebMathTraining.Models
{
  public class TodoItem : CatalogEntityModel
  {
    public int TodoItemId { get { return Id; } set { Id = value; } }

    public string OwnerId { get; set; }
    
    public bool IsDone { get; set; }
    
    [Required]
    public string Title { get; set; }

    public string DueAt { get; set; } //DateTimeOffset?
  }

}
