using Microsoft.EntityFrameworkCore;
using WEB_253505_Yeudakavets.Domain.Entities;

namespace WEB_253505_Yeudakavets.API.Data
{
	public class DbInitializer
	{
		public static async Task SeedData(WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			if (!context.Categories.Any())
			{
				var categories = new List<Category>
				{
				  new() { Name = "Зимняя обувь", NormalizedName = "winter-boots" },
				  new() { Name = "Кроссовки", NormalizedName = "sneakers" },
				  new() { Name = "Куртки", NormalizedName = "jackets" },
				  new() { Name = "Рубашки", NormalizedName = "shirts" },
				  new() { Name = "Брюки", NormalizedName = "pants" },
				  new() { Name = "Носки", NormalizedName = "socks" }
				};
				await context.Categories.AddRangeAsync(categories);
				await context.SaveChangesAsync();
			}
			var baseUrl = app.Configuration.GetValue<string>("ApplicationUrl");
			if (!context.Clothes.Any())
			{
				var categories = await context.Categories.ToListAsync();
				var games = new List<Clothing>
				{
					new Clothing { Name = "Ботинки Timberland>", Description = "Зимние ботинки, теплые и удобные", Price = 200, Image = $"{baseUrl}/Images/Timbers.jpg", Category = categories.Find(c => c.NormalizedName.Equals("winter-boots")), CategoryId = categories.Find(c => c.NormalizedName.Equals("winter-boots"))?.Id ?? 0  },
					new Clothing { Name = "Кроссовки Nike", Description = "Легкие и удобные для повседневной носки", Price = 150, Image = $"{baseUrl}/Images/Nike.jpg", Category = categories.Find(c => c.NormalizedName.Equals("sneakers")), CategoryId = categories.Find(c => c.NormalizedName.Equals("sneakers"))?.Id ?? 0 },
					new Clothing { Name = "Куртка зимняя", Description = "Теплая куртка для холодной погоды", Price = 500, Image = $"{baseUrl}/Images/Jacket.jpg", Category = categories.Find(c => c.NormalizedName.Equals("jackets")), CategoryId = categories.Find(c => c.NormalizedName.Equals("jackets"))?.Id ?? 0 },
					new Clothing { Name = "Рубашка в клетку", Description = "Стильная рубашка для повседневной носки", Price = 300, Image = $"{baseUrl}/Images/Shirt.jpg", Category = categories.Find(c => c.NormalizedName.Equals("shirts")), CategoryId = categories.Find(c => c.NormalizedName.Equals("shirts"))?.Id ?? 0 },
					new Clothing { Name = "Брюки классические", Description = "Комфортные брюки для офиса", Price = 400, Image = $"{baseUrl}/Images/Pants.jpg", Category = categories.Find(c => c.NormalizedName.Equals("pants")), CategoryId = categories.Find(c => c.NormalizedName.Equals("pants"))?.Id ?? 0 },
					new Clothing { Name = "Носки хлопковые", Description = "Носки для повседневного ношения", Price = 50, Image = $"{baseUrl}/Images/Socks.jpg", Category = categories.Find(c => c.NormalizedName.Equals("socks")), CategoryId = categories.Find(c => c.NormalizedName.Equals("socks"))?.Id ?? 0 },
					new Clothing { Name = "Кроссовки Adidas", Description = "Удобные кроссовки для активного отдыха", Price = 180, Image = $"{baseUrl}/Images/Adidas.jpg", Category = categories.Find(c => c.NormalizedName.Equals("sneakers")), CategoryId = categories.Find(c => c.NormalizedName.Equals("sneakers"))?.Id ?? 0 },
					new Clothing { Name = "Летняя куртка", Description = "Легкая куртка для весенней погоды", Price = 400, Image = $"{baseUrl}/Images/SpringJacket.jpg", Category = categories.Find(c => c.NormalizedName.Equals("jackets")), CategoryId = categories.Find(c => c.NormalizedName.Equals("jackets"))?.Id ?? 0 },
					new Clothing { Name = "Рубашка поло", Description = "Стильная рубашка поло для повседневной носки", Price = 250, Image = $"{baseUrl}/Images/PoloShirt.jpg", Category = categories.Find(c => c.NormalizedName.Equals("shirts")), CategoryId = categories.Find(c => c.NormalizedName.Equals("shirts"))?.Id ?? 0 },
					new Clothing { Name = "Спортивные брюки", Description = "Комфортные брюки для тренировок", Price = 300, Image = $"{baseUrl}/Images/SportPants.jpg", Category = categories.Find(c => c.NormalizedName.Equals("pants")), CategoryId = categories.Find(c => c.NormalizedName.Equals("pants"))?.Id ?? 0 }
				};
				await context.Clothes.AddRangeAsync(games);
				await context.SaveChangesAsync();
			}

		}
	}
}
