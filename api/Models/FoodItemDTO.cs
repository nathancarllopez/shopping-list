using System.ComponentModel.DataAnnotations;

namespace ShoppingListApi.Models;

public class FoodItemDTO
{
  public long Id { get; set; }
  
  [Required(ErrorMessage = "Name is required.")]
  public string? Name { get; set; }
  [Required(ErrorMessage = "Store is required.")]
  public string? Store { get; set; }

  public string? Price { get; set; }
  public int Quantity { get; set; }
  public List<string> Tags { get; set; } = new();
}