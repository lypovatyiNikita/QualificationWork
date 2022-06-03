using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Application.Areas.Methodist.Controllers
{
	[Area("Methodist")]
	public class StudyingGraphController : Controller
	{
		public IActionResult SaveNewUrl(string url)
		{
			Application.Controllers.StudyingGraphController.SheetUrl = url;
			System.IO.File.WriteAllText(@"wwwroot/json/graph.txt", url);
			return RedirectToAction("StudyingGraph", "StudyingGraph");
		}
	}
}
