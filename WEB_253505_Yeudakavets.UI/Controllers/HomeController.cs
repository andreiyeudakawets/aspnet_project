using Microsoft.AspNetCore.Mvc;
using WEB_253505_Yeudakavets.UI.Models;

namespace WEB_253505_Yeudakavets.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			ViewData["Title"] = "Лабораторная работа 1 и 2";

			var model = new IndexViewModel(new List<ListDemo>()
			{
				new ListDemo { Id = 1, Name = "Item 1" },
				new ListDemo { Id = 2, Name = "Item 2" },
				new ListDemo { Id = 3, Name = "Item 3" },
				new ListDemo { Id = 4, Name = "Item 4" },
				new ListDemo { Id = 5, Name = "Item 5" }
			});
			return View(model);
        }
    }
}
