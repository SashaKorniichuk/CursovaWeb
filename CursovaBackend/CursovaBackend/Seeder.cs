using CursovaBackend.Entities;

namespace CursovaBackend
{
    public static class Seeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Products.Any())
            {
                var products = new[]
                {
                    new Product
                    {
                        Name = "Apple",
                        Price = 0.99f,
                        ImageName = "apple.jpg"
                    },
                    new Product
                    {
                        Name = "Banana",
                        Price = 0.49f,
                        ImageName = "banana.jpg"
                    },
                    new Product
                    {
                        Name = "Chicken Breast",
                        Price = 5.99f,
                        ImageName = "chickenbreast.jpg"
                    },
                    new Product
                    {
                        Name = "Orange",
                        Price = 0.79f,
                        ImageName = "orange.jpg"
                    },
                    new Product
                    {
                        Name = "Lettuce",
                        Price = 1.99f,
                        ImageName = "lettuce.jpg"
                    },
                    new Product
                    {
                        Name = "Beef Steak",
                        Price = 12.99f,
                        ImageName = "beefsteak.jpg"
                    },
                    new Product
                    {
                        Name = "Salmon Fillet",
                        Price = 9.99f,
                        ImageName = "salmonfillet.jpg"
                    },
                    new Product
                    {
                        Name = "Milk",
                        Price = 2.49f,
                        ImageName = "milk.jpg"
                    },
                    new Product
                    {
                        Name = "Tomato",
                        Price = 1.29f,
                        ImageName = "tomato.jpg"
                    },
                    new Product
                    {
                        Name = "Eggs",
                        Price = 2.99f,
                        ImageName = "eggs.jpg"
                    },
                    new Product
                    {
                        Name = "Pasta",
                        Price = 3.49f,
                        ImageName = "pasta.jpg"
                    },
                    new Product
                    {
                        Name = "Yogurt",
                        Price = 1.99f,
                        ImageName = "yogurt.jpg"
                    },
                    new Product
                    {
                        Name = "Bread",
                        Price = 2.49f,
                        ImageName = "bread.jpg"
                    },
                    new Product
                    {
                        Name = "Carrots",
                        Price = 0.99f,
                        ImageName = "carrots.jpg"
                    },
                    new Product
                    {
                        Name = "Potatoes",
                        Price = 1.49f,
                        ImageName = "potatoes.jpg"
                    },
                    new Product
                    {
                        Name = "Cheese",
                        Price = 3.99f,
                        ImageName = "cheese.jpg"
                    },
                    new Product
                    {
                        Name = "Salad Mix",
                        Price = 2.99f,
                        ImageName = "saladmix.jpg"
                    },
                    new Product
                    {
                        Name = "Cereal",
                        Price = 4.99f,
                        ImageName = "cereal.jpg"
                    },
                };
                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }

    }
}
