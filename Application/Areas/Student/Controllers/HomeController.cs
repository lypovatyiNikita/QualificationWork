using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Areas.Student.Controllers
{
	[Area("Student")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
