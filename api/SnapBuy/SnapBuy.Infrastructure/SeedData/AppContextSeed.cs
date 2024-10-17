using SnapBuy.Domain.Entities;
using System.Text.Json;

namespace SnapBuy.Infrastructure.SeedData
{
    public class AppContextSeed
    {
        public static async Task SeedDataAsync(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("../SnapBuy.Infrastructure/SeedData/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products == null)
                    return;

                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
