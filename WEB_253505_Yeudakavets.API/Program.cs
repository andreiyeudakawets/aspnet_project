
using Microsoft.EntityFrameworkCore;
using WEB_253505_Yeudakavets.API.Data;
using WEB_253505_Yeudakavets.API.Services.CategoryService;
using WEB_253505_Yeudakavets.API.Services.ProductService;

namespace WEB_253505_Yeudakavets.API
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			string connectionString = builder.Configuration.GetConnectionString("Default");
			builder.Services.AddDbContext<AppDbContext>(options =>
							options.UseSqlite(connectionString));


			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IClothingService, ClothingService>();

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			var app = builder.Build();
			
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			//using var scope = app.Services.CreateScope();
			//var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			//await context.Database.MigrateAsync();

			await DbInitializer.SeedData(app);

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.UseStaticFiles(); //Для доступа к файлам изображений в классе program добавьте в конвейер Middleware компонент статических файлов.
			app.MapControllers();

			app.Run();
		}
	}
}
