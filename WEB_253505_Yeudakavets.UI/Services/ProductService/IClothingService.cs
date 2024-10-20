using WEB_253505_Yeudakavets.Domain.Entities;
using WEB_253505_Yeudakavets.Domain.Models;

namespace WEB_253505_Yeudakavets.UI.Services.ProductService
{
	public interface IClothingService
	{
		public Task<ResponseData<ListModel<Clothing>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1);
		public Task<ResponseData<Clothing>> GetProductByIdAsync(int id);
		public Task UpdateProductAsync(int id, Clothing product, IFormFile? formFile);
		public Task DeleteProductAsync(int id);
		public Task<ResponseData<Clothing>> CreateProductAsync(Clothing product, IFormFile? formFile);
	}
}
