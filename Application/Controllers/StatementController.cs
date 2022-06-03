using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
	[Authorize]
	public class StatementController : Controller
	{
		public IActionResult Statement()
		{
			return View();
		}
	}
}
