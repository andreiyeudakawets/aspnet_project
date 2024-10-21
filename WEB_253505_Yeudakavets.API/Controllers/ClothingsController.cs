using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_253505_Yeudakavets.API.Data;
using WEB_253505_Yeudakavets.API.Services.ProductService;
using WEB_253505_Yeudakavets.Domain.Entities;
using WEB_253505_Yeudakavets.Domain.Models;

namespace WEB_253505_Yeudakavets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingsController : ControllerBase
    {
		//private readonly AppDbContext _context;
		private readonly IClothingService _productService;
		public ClothingsController(IClothingService productService)
		{
			_productService = productService;
		}


		/*public ClothingsController(AppDbContext context)
        {
            _context = context;
        }*/
	
		// GET: api/Clothings/category/{category}?pageNo=1&pageSize=3
		[HttpGet("category/{category}")]
		public async Task<ActionResult<ResponseData<List<Clothing>>>> GetClothes(string category, int pageNo = 1, int pageSize = 3)
		{
			return Ok(await _productService.GetProductListAsync(
							category,
							pageNo,
							pageSize));
		}
		/*[HttpGet]
        public async Task<ActionResult<IEnumerable<Clothing>>> GetClothes()
        {
            return await _context.Clothes.ToListAsync();
        }*/

		//GET: api/Clothings
		[HttpGet]
		public async Task<ActionResult<ResponseData<List<Clothing>>>> GetDishes(string? category, int pageNo = 1, int pageSize = 3)
		{
			return Ok(await _productService.GetProductListAsync(
				category,
				pageNo,
				pageSize));
		}

		// GET: api/Clothings/5
		[HttpGet("{id}")]
		//[AllowAnonymous]
		public async Task<ActionResult<ResponseData<Clothing>>> GetClothing(int id)
		{
			var result = await _productService.GetProductByIdAsync(id);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}
		/*[HttpGet("{id}")]
        public async Task<ActionResult<Clothing>> GetClothing(int id)
        {
            var clothing = await _context.Clothes.FindAsync(id);

            if (clothing == null)
            {
                return NotFound();
            }

            return clothing;
        }*/

		// PUT: api/Clothings/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<ActionResult<ResponseData<Clothing>>> PutClothing(int id, Clothing clothing)
        {
			if (id != clothing.Id)
			{
				return BadRequest();
			}
			await _productService.UpdateProductAsync(id, clothing);
			//    return Ok();
			return NoContent();
		}
		/*[HttpPut("{id}")]
        public async Task<ActionResult<ResponseData<Clothing>>> PutClothing(int id, Clothing clothing)
        {
            if (id != clothing.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        */
		// POST: api/Clothings
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		//[Authorize(Policy = "admin")]
		public async Task<ActionResult<ResponseData<Clothing>>> PostClothing(Clothing clothing)
        {
			var result = await _productService.CreateProductAsync(clothing);
			return Ok(result);
		}
		/*[HttpPost]
        public async Task<ActionResult<Clothing>> PostClothing(Clothing clothing)
        {
            _context.Clothes.Add(clothing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothing", new { id = clothing.Id }, clothing);
        }
        */

		// DELETE: api/Clothings/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteClothing(int id)
        {
			await _productService.DeleteProductAsync(id);
			return NoContent();
		}
		/*
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothing(int id)
        {
            var clothing = await _context.Clothes.FindAsync(id);
            if (clothing == null)
            {
                return NotFound();
            }

            _context.Clothes.Remove(clothing);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/
		/*
		private bool ClothingExists(int id)
        {
            return _context.Clothes.Any(e => e.Id == id);
        }*/

		[HttpPost("{id}/SaveImage")]
		public async Task<ActionResult<ResponseData<string>>> SaveImage(int id, IFormFile formFile)
		{
			var result = await _productService.SaveImageAsync(id, formFile);
			return Ok(result);
		}	
	}
}
