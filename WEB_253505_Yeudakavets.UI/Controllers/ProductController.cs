using Microsoft.AspNetCore.Mvc;
using WEB_253505_Yeudakavets.Domain.Entities;
using WEB_253505_Yeudakavets.UI.Services.CategoryService;
using WEB_253505_Yeudakavets.UI.Services.ProductService;

namespace WEB_253505_Yeudakavets.UI.Controllers
{
    public class ProductController : Controller
	{
		private readonly IClothingService _productService;
		private readonly ICategoryService _categoryService;

		public ProductController(IClothingService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}
		public async Task<IActionResult> Index(string? category, int pageNo = 1)
		{
			var productResponse = await _productService.GetProductListAsync(category, pageNo);
			if (!productResponse.Successful)
				return NotFound(productResponse.ErrorMessage);
			var categoriesResponse = await _categoryService.GetCategoryListAsync();
			if (!categoriesResponse.Successful)
				return NotFound(categoriesResponse.ErrorMessage);
			var categories = categoriesResponse.Data;
			ViewData["currentCategory"] = categories.FirstOrDefault(c => c.NormalizedName == category)?.Name ?? "Все";
			ViewData["categories"] = categories;

			return View(productResponse.Data);
		}
	}
}
