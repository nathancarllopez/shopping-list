namespace ShoppingListApi.Models;

public class FoodItemDTO
{
  public long Id { get; set; }
  public string? Name { get; set; }
  public int Quantity { get; set; }
}