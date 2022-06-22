using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Domain;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
	public class HomeController : Controller
	{
		private readonly DataManager dataManagerRef;

		public HomeController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult Index(int days)
		{
			Startup.IsMethodistModeNow = false;
			if (User.IsInRole(AllRoles.MethodistRole))
			{
				Startup.IsMethodistModeNow = true;
				return Redirect("~/" + AllRoles.MethodistRole);
			}
			ScheduleViewModel model = new ScheduleViewModel();
			if (days == 0)
				model.CurrentDateTime = DateTime.Today;
			else
				model.CurrentDateTime = DateTime.Today.AddDays(days);

			model.DateInString = model.CurrentDateTime.ToString("dd MMMM");
			model.CurrentSchedules = dataManagerRef.ScheduleRepositoryRef.GetAllSheduleByDate(model.CurrentDateTime).ToArray();
			model.AllSheduleBlocks = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(dataManagerRef.ScheduleBlockRepositoryRef.GetAllBlocks().ToList(), "Id", "Title");

			return View(new HomeViewModel
			{
				NewsBlocks = dataManagerRef.NewsRepositoryRef.GetAllNews().OrderByDescending(x => x.CreateDate),
				ScheduleViewModel = model
			});
		}
	}
}
