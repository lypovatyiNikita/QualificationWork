using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			Startup.IsMethodistModeNow = false;
			if (User.IsInRole(AllRoles.MethodistRole))
			{
				Startup.IsMethodistModeNow = true;
				return Redirect("~/" + AllRoles.MethodistRole);
			}
			return View();
		}
	}
}
