using Microsoft.EntityFrameworkCore;
using WEB_253505_Yeudakavets.Domain.Entities;

namespace WEB_253505_Yeudakavets.API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		public DbSet<Clothing> Clothes { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
