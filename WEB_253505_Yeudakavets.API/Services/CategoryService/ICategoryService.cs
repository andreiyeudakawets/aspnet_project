using WEB_253505_Yeudakavets.Domain.Entities;
using WEB_253505_Yeudakavets.Domain.Models;

namespace WEB_253505_Yeudakavets.API.Services.CategoryService
{
	public interface ICategoryService
	{
		public Task<ResponseData<List<Category>>> GetCategoryListAsync();
	}
}
