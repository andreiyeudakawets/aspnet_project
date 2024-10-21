using Microsoft.EntityFrameworkCore;
using WEB_253505_Yeudakavets.API.Data;
using WEB_253505_Yeudakavets.Domain.Entities;
using WEB_253505_Yeudakavets.Domain.Models;

namespace WEB_253505_Yeudakavets.API.Services.CategoryService
{
	public class CategoryService : ICategoryService
	{
		private readonly AppDbContext _context;
		public CategoryService(AppDbContext context)
		{
			_context = context;
		}
		public async Task<ResponseData<List<Category>>> GetCategoryListAsync()
		{
			var categories = await _context.Categories.ToListAsync();
			return ResponseData<List<Category>>.Success(categories);
		}
	}
}
