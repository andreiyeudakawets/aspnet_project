using Microsoft.EntityFrameworkCore;
using WEB_253505_Yeudakavets.API.Data;
using WEB_253505_Yeudakavets.Domain.Entities;
using WEB_253505_Yeudakavets.Domain.Models;

namespace WEB_253505_Yeudakavets.API.Services.ProductService
{
	public class ClothingService : IClothingService
	{
		private readonly AppDbContext _context;
		private readonly int _maxPageSize = 20;
		public ClothingService(AppDbContext context)
		{
			_context = context;
		}
		public Task<ResponseData<string>> SaveImageAsync(int id, IFormFile formFile)
		{
			throw new NotImplementedException();
		}
		public async Task<ResponseData<Clothing>> CreateProductAsync(Clothing product)
		{
			await _context.Clothes.AddAsync(product);
			await _context.SaveChangesAsync();

			return ResponseData<Clothing>.Success(product);
		}
		public async Task DeleteProductAsync(int id)
		{
			var dish = await _context.Clothes.FindAsync(id);
			if (dish == null)
			{
				throw new Exception("Товар не найден");
			}
			_context.Clothes.Remove(dish);
			await _context.SaveChangesAsync();
		}
		public async Task<ResponseData<Clothing>> GetProductByIdAsync(int id)
		{
			var dish = await _context.Clothes.Include(d => d.Category).FirstOrDefaultAsync(d => d.Id == id);
			if (dish == null)
			{
				return ResponseData<Clothing>.Error("Товар не найден");
			}
			return ResponseData<Clothing>.Success(dish);
		}
		public async Task<ResponseData<ListModel<Clothing>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1, int pageSize = 3)
		{
			if (pageSize > _maxPageSize)
				pageSize = _maxPageSize;
			var query = _context.Clothes.AsQueryable();
			var dataList = new ListModel<Clothing>();
			query = query.Where(d => categoryNormalizedName == null || d.Category.NormalizedName.Equals(categoryNormalizedName));
			var count = await query.CountAsync();
			if (count == 0)
			{
				return ResponseData<ListModel<Clothing>>.Success(dataList);
			}
			int totalPages = (int)Math.Ceiling(count / (double)pageSize);
			if (pageNo > totalPages)
				return ResponseData<ListModel<Clothing>>.Error("Нет такой страницы");
			dataList.Items = await query
				.OrderBy(d => d.Id)
				.Skip((pageNo - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
			dataList.CurrentPage = pageNo;
			dataList.TotalPages = totalPages;

			return ResponseData<ListModel<Clothing>>.Success(dataList);
		}
		public async Task UpdateProductAsync(int id, Clothing product)
		{
			var existingClothing = await _context.Clothes.FindAsync(id);
			if (existingClothing == null)
			{
				throw new Exception("Одежда не найдена");
			}
			existingClothing.Name = product.Name;
			existingClothing.Description = product.Description;
			existingClothing.Price = product.Price;
			existingClothing.CategoryId = product.CategoryId;
			existingClothing.Image = product.Image;
			await _context.SaveChangesAsync();
		}
	}
}
