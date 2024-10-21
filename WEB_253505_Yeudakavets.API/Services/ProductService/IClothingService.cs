using WEB_253505_Yeudakavets.Domain.Entities;
using WEB_253505_Yeudakavets.Domain.Models;

namespace WEB_253505_Yeudakavets.API.Services.ProductService
{
	public interface IClothingService
	{
		Task<ResponseData<ListModel<Clothing>>> GetProductListAsync(
		string? categoryNormalizedName, int pageNo = 1, int pageSize = 3);
		Task<ResponseData<Clothing>> GetProductByIdAsync(int id);
		Task UpdateProductAsync(int id, Clothing product);
		Task DeleteProductAsync(int id);
		Task<ResponseData<Clothing>> CreateProductAsync(Clothing product);
		Task<ResponseData<string>> SaveImageAsync(int id, IFormFile formFile);
	}
}
