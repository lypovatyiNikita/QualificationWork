using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
	public class StudyingGraphController : Controller
	{
		public static string SheetUrl = "";

		public StudyingGraphController()
		{
			if (SheetUrl == "")
			{
				SheetUrl = System.IO.File.ReadAllText(@"wwwroot/json/graph.txt");
			}
		}

		public IActionResult StudyingGraph()
		{
			return View();
		}
	}
}
