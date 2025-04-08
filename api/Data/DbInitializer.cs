using ShoppingListApi.Models;

namespace ShoppingListApi.Data
{
  public static class DbInitializer
  {
    public static void Initialize(FoodItemContext context)
    {
      context.Database.EnsureCreated();

      if (context.FoodItems.Any())
      {
        return;
      }

      var items = new FoodItem[]
      {
        new FoodItem { Name = "Apples", Quantity = 1, Secret = "mySecret" },
        new FoodItem { Name = "Bananas", Quantity = 1, Secret = "mySecret" },
        new FoodItem { Name = "Cherries", Quantity = 1, Secret = "mySecret" },
        new FoodItem { Name = "Dalmas", Quantity = 1, Secret = "mySecret" },
        new FoodItem { Name = "E'Clairs", Quantity = 7, Secret = "mySecret" }
      };

      context.FoodItems.AddRange(items);
      context.SaveChanges();
    }
  }
}