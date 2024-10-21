using WEB_253505_Yeudakavets.UI.Extensions;
using WEB_253505_Yeudakavets.UI.Services.ProductService;
using WEB_253505_Yeudakavets.UI.ApiServices;


namespace WEB_253505_Yeudakavets.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			
			
			//builder.Services
			//.AddHttpClient<IProductService, ApiProductService>(opt =>
			//opt.BaseAddress = new Uri(UriData.ApiUri));
			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var uriData = builder.Configuration.GetSection("UriData").Get<UriData>();
			builder.RegisterCustomServices(uriData);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
