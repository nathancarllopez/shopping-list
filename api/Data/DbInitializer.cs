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
        new FoodItem
        {
          Name = "Apples",
          Store = "Fresh Thyme",
          Price = "$2.99",
          Quantity = 1,
          Tags = new List<string> { "Fruit"}
        },
        new FoodItem
        {
          Name = "Bananas",
          Store = "Trader Joes",
          Price = "$10.00",
          Quantity = 1,
          Tags = new List<string> { "Fruit" }
        },
        new FoodItem
        {
          Name = "Cherries",
          Store = "Fresh Thyme",
          Price = "$1.23",
          Quantity = 3,
          Tags = new List<string> { "Fruit" }
        },
        new FoodItem
        {
          Name = "Dolmas",
          Store = "Trader Joes",
          Price = "$4.50",
          Quantity = 4,
          Tags = new List<string> { "Shelf Stable" }
        },
        new FoodItem
        {
          Name = "E'Clairs",
          Store = "Fresh Thyme",
          Price = "$7.99",
          Quantity = 7,
          Tags = new List<string> { "Dessert" }
        }
      };

      context.FoodItems.AddRange(items);
      context.SaveChanges();
    }
  }
}