using WEB_253505_Yeudakavets.UI.Services.CategoryService;
using WEB_253505_Yeudakavets.UI.Services.ProductService;

namespace WEB_253505_Yeudakavets.UI.Extensions
{
	
	public static class HostingExtensions
	{
		//В этом методе будем регистрировать созданные сервисы.
		public static void RegisterCustomServices(
		this WebApplicationBuilder builder)
		{
			builder.Services.AddScoped<ICategoryService, MemoryCategoryService>();
			builder.Services.AddScoped<IClothingService, MemoryClothingService>();
		}
	}
}
