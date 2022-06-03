using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Domain.Entities;
using Application.Domain;

namespace Application.Controllers
{
	public class ScheduleController : Controller
	{
		private readonly DataManager dataManagerRef;

		public ScheduleController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult Schedule(ScheduleViewModel model)
		{
			if (model.CurrentDateTime == default) 
			{
				return View(new ScheduleViewModel() { CurrentDateTime = DateTime.Today, CurrentSchedules = dataManagerRef.ScheduleRepositoryRef.GetAllSheduleByDate(DateTime.Today).ToArray(), AllSheduleBlocks= new Microsoft.AspNetCore.Mvc.Rendering.SelectList(dataManagerRef.ScheduleBlockRepositoryRef.GetAllBlocks().ToList(), "Id", "Title") });
			}
			model.Test = model.CurrentDateTime.ToString();
			model.CurrentSchedules = dataManagerRef.ScheduleRepositoryRef.GetAllSheduleByDate(model.CurrentDateTime).ToArray();
			model.AllSheduleBlocks = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(dataManagerRef.ScheduleBlockRepositoryRef.GetAllBlocks().ToList(),"Id","Title");

			return View(model);
		}
	}
}
