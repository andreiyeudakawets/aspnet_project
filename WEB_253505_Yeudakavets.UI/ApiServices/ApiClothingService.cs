using System.Text.Json;
using System.Text;
using WEB_253505_Yeudakavets.Domain.Models;
using WEB_253505_Yeudakavets.UI.Services.ProductService;
using WEB_253505_Yeudakavets.Domain.Entities;

namespace WEB_253505_Yeudakavets.UI.ApiServices
{
	public class ApiClothingService : IClothingService
	{
		private readonly HttpClient _httpClient;
		private readonly string _pageSize;
		private readonly JsonSerializerOptions _serializerOptions;
		private readonly ILogger<ApiClothingService> _logger;
		public ApiClothingService(HttpClient httpClient, IConfiguration configuration, ILogger<ApiClothingService> logger)
		{
			_httpClient = httpClient;
			_pageSize = configuration.GetSection("ItemsPerPage").Value;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};
			_logger = logger;
		}
		public async Task<ResponseData<ListModel<Clothing>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
		{
			// подготовка URL запроса
			var urlString
			= new
			 StringBuilder($"{_httpClient.BaseAddress.AbsoluteUri}clothings");
			// добавить категорию в маршрут
			if (categoryNormalizedName != null)
			{
				urlString.Append($"/category/{categoryNormalizedName}/");
			};
			var a = new Uri(urlString.ToString());
			// добавить номер страницы в маршрут
			if (pageNo > 1)
			{
				urlString.Append($"?pageNo={pageNo}");
			};
			// добавить размер страницы в строку запроса
			if (!_pageSize.Equals("3"))
			{
				if (pageNo > 1)
					urlString.Append($"&pageSize={_pageSize}");
				else
					urlString.Append($"?pageSize={_pageSize}");
			}

			// отправить запрос к API
			var response = await _httpClient.GetAsync(new Uri(urlString.ToString()));

			if (response.IsSuccessStatusCode)
			{
				try
				{
					return await response.Content.ReadFromJsonAsync<ResponseData<ListModel<Clothing>>>(_serializerOptions);
				}
				catch (JsonException ex)
				{
					_logger.LogError($"-----> Ошибка: {ex.Message}");
					return ResponseData<ListModel<Clothing>>
					.Error($"Ошибка: {ex.Message}");
				}
			}
			_logger.LogError($"-----> Данные не получены от сервера. Error: {response.StatusCode.ToString()}");
			return ResponseData<ListModel<Clothing>>
				   .Error($"Данные не получены от сервера. Error: {response.StatusCode.ToString()}");
		}
		public async Task<ResponseData<Clothing>> CreateProductAsync(Clothing product, IFormFile? formFile)
		{
			var uri = new Uri(_httpClient.BaseAddress.AbsoluteUri + "Clothings");

			var response = await _httpClient.PostAsJsonAsync(
			uri,
			product,
			_serializerOptions);
			if (response.IsSuccessStatusCode)
			{
				var data = await response
					.Content
					.ReadFromJsonAsync<ResponseData<Clothing>>(_serializerOptions);

				return data;
			}
			_logger
			.LogError($"-----> object not created. Error: {response.StatusCode.ToString()}");
			return ResponseData<Clothing>.Error($"Объект не добавлен. Error: {response.StatusCode.ToString()}");
		}
		public Task<ResponseData<Clothing>> GetProductByIdAsync(int id)
		{
			throw new NotImplementedException();
		}
		public Task UpdateProductAsync(int id, Clothing clothing, IFormFile? formFile)
		{
			throw new NotImplementedException();
		}
		public Task DeleteProductAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
