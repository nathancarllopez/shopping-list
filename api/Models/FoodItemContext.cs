using Microsoft.EntityFrameworkCore;

namespace ShoppingListApi.Models;

public class FoodItemContext : DbContext
{
  public FoodItemContext(DbContextOptions<FoodItemContext> options)
    : base(options)
  {
  }

  public DbSet<FoodItem> FoodItems { get; set; } = null!;
}