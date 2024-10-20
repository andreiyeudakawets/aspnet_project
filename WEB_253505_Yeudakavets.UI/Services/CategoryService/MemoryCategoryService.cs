using WEB_253505_Yeudakavets.Domain.Entities;
using WEB_253505_Yeudakavets.Domain.Models;

namespace WEB_253505_Yeudakavets.UI.Services.CategoryService
{
	public class MemoryCategoryService : ICategoryService
	{
		public Task<ResponseData<List<Category>>> GetCategoryListAsync()
		{
			var categories = new List<Category>
			{
			  new Category { Id = 1, Name = "Зимняя обувь", NormalizedName = "winter-boots" },
			  new Category { Id = 2, Name = "Кроссовки", NormalizedName = "sneakers" },
			  new Category { Id = 3, Name = "Куртки", NormalizedName = "jackets" },
			  new Category { Id = 4, Name = "Рубашки", NormalizedName = "shirts" },
			  new Category { Id = 5, Name = "Брюки", NormalizedName = "pants" },
			  new Category { Id = 6, Name = "Носки", NormalizedName = "socks" }
			};
			var result = ResponseData<List<Category>>.Success(categories);
			return Task.FromResult(result);
		}
	}
}
