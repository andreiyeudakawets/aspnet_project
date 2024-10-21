using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB_253505_Yeudakavets.UI.Models
{
	public class IndexViewModel
	{
		public SelectList ListDemo { get; }

		public IndexViewModel(IEnumerable<ListDemo> listDemo)
		{
			ListDemo = new SelectList(listDemo, "Id", "Name");
		}
	}
}
