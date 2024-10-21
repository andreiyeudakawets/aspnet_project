using Microsoft.AspNetCore.Mvc;
using WEB_253505_Yeudakavets.Domain.Entities;
using WEB_253505_Yeudakavets.Domain.Models;
using WEB_253505_Yeudakavets.UI.Services.CategoryService;

namespace WEB_253505_Yeudakavets.UI.Services.ProductService
{
	public class MemoryClothingService : IClothingService
	{
		private readonly IConfiguration _config;
		private List<Clothing> _clothes;
		private List<Category> _categories;
		public MemoryClothingService([FromServices] IConfiguration config, ICategoryService categoryService)
		{
			_categories = categoryService.GetCategoryListAsync()
			.Result
			.Data;
			SetupData();
			_config = config;
		}

		public Task<ResponseData<Clothing>> CreateProductAsync(Clothing product, IFormFile? formFile)
		{
			throw new NotImplementedException();
		}

		public Task DeleteProductAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseData<Clothing>> GetProductByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ResponseData<ListModel<Clothing>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
		{
			if (pageNo < 1)
				return Task.FromResult(ResponseData<ListModel<Clothing>>.Error("Нет такой страницы"));
			var data = _clothes
			.Where(d => categoryNormalizedName == null || d.Category.NormalizedName.Equals(categoryNormalizedName))
			.ToList();
			int itemsPerPage = _config.GetValue<int>("ItemsPerPage");
			int totalItems = data.Count;
			int totalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);
			var pagedItems = data
			.Skip((pageNo - 1) * itemsPerPage)
			.Take(itemsPerPage)
			.ToList();
			var result = new ListModel<Clothing>
			{
				Items = pagedItems,
				CurrentPage = pageNo,
				TotalPages = totalPages
			};

			return Task.FromResult(ResponseData<ListModel<Clothing>>.Success(result));
		}

		public Task UpdateProductAsync(int id, Clothing product, IFormFile? formFile)
		{
			throw new NotImplementedException();
		}

		private void SetupData()
		{
			_clothes = new List<Clothing>
			{
				new Clothing { Id = 1, Name = "Ботинки Timberland>", Description = "Зимние ботинки, теплые и удобные", Price = 200, Image = "Images/Timbers.jpg", Category = _categories.Find(c => c.NormalizedName.Equals("winter-boots")), CategoryId = _categories.Find(c => c.NormalizedName.Equals("winter-boots"))?.Id ?? 0  },
				new Clothing { Id = 2, Name = "Кроссовки Nike", Description = "Легкие и удобные для повседневной носки", Price = 150, Image = "Images/Nike.jpg", Category = _categories.Find(c => c.NormalizedName.Equals("sneakers")), CategoryId = _categories.Find(c => c.NormalizedName.Equals("sneakers"))?.Id ?? 0 },
				new Clothing { Id = 3, Name = "Куртка зимняя", Description = "Теплая куртка для холодной погоды", Price = 500, Image = "Images/Jacket.jpg", Category = _categories.Find(c => c.NormalizedName.Equals("jackets")), CategoryId = _categories.Find(c => c.NormalizedName.Equals("jackets"))?.Id ?? 0 },
				new Clothing { Id = 4, Name = "Рубашка в клетку", Description = "Стильная рубашка для повседневной носки", Price = 300, Image = "Images/Shirt.jpg", Category = _categories.Find(c => c.NormalizedName.Equals("shirts")), CategoryId = _categories.Find(c => c.NormalizedName.Equals("shirts"))?.Id ?? 0 },
				new Clothing { Id = 5, Name = "Брюки классические", Description = "Комфортные брюки для офиса", Price = 400, Image = "Images/Pants.jpg", Category = _categories.Find(c => c.NormalizedName.Equals("pants")), CategoryId = _categories.Find(c => c.NormalizedName.Equals("pants"))?.Id ?? 0 },
				new Clothing { Id = 6, Name = "Носки хлопковые", Description = "Носки для повседневного ношения", Price = 50, Image = "Images/Socks.jpg", Category = _categories.Find(c => c.NormalizedName.Equals("socks")), CategoryId = _categories.Find(c => c.NormalizedName.Equals("socks"))?.Id ?? 0 },
				new Clothing { Id = 7, Name = "Кроссовки Adidas", Description = "Удобные кроссовки для активного отдыха", Price = 180, Image = "Images/Adidas.jpg", Category = _categories.Find(c => c.NormalizedName.Equals("sneakers")), CategoryId = _categories.Find(c => c.NormalizedName.Equals("sneakers"))?.Id ?? 0 },
				new Clothing { Id = 8, Name = "Летняя куртка", Description = "Легкая куртка для весенней погоды", Price = 400, Image = "Images/SpringJacket.jpg", Category = _categories.Find(c => c.NormalizedName.Equals("jackets")), CategoryId = _categories.Find(c => c.NormalizedName.Equals("jackets"))?.Id ?? 0 },
				new Clothing { Id = 9, Name = "Рубашка поло", Description = "Стильная рубашка поло для повседневной носки", Price = 250, Image = "Images/PoloShirt.jpg", Category = _categories.Find(c => c.NormalizedName.Equals("shirts")), CategoryId = _categories.Find(c => c.NormalizedName.Equals("shirts"))?.Id ?? 0 },
				new Clothing { Id = 10, Name = "Спортивные брюки", Description = "Комфортные брюки для тренировок", Price = 300, Image = "Images/SportPants.jpg", Category = _categories.Find(c => c.NormalizedName.Equals("pants")), CategoryId = _categories.Find(c => c.NormalizedName.Equals("pants"))?.Id ?? 0 }
			};
		}
	}
}
