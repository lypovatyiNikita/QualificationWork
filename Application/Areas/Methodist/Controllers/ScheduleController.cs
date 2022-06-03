using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain;
using Application.Domain.Entities;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Areas.Methodist.Controllers
{
	[Area("Methodist")]
	public class ScheduleController : Controller
	{
		private readonly DataManager dataManagerRef;

		public ScheduleController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult AddParaInSchedule(Guid paraID, int paraNumber, DateTime data)
		{
			Schedule newSchedule = new Schedule()
			{
				BlockId = paraID,
				Couple = paraNumber,
				DateOfBlock = data
			};
			dataManagerRef.ScheduleRepositoryRef.AddAndSaveBlock(newSchedule);
			return ReturnBackToStandartSchedule(data);
		}

		private IActionResult ReturnBackToStandartSchedule(DateTime dateToBack)
		{
			return RedirectToAction("Schedule", "Schedule", new ScheduleViewModel()
			{
				CurrentDateTime = dateToBack,
				CurrentSchedules = dataManagerRef.ScheduleRepositoryRef.GetAllSheduleByDate(DateTime.Today).ToArray(),
				AllSheduleBlocks = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(dataManagerRef.ScheduleBlockRepositoryRef.GetAllBlocks().ToList(), "Id", "Title")
			});
		}

		public IActionResult AddScheduleBlock()
		{
			return View(new ScheduleBlock());
		}

		public IActionResult EditScheduleBlock(Guid blockID)
		{
			return View("AddScheduleBlock", dataManagerRef.ScheduleBlockRepositoryRef.GetBlockById(blockID));
		}

		public IActionResult SaveScheduleBlock(ScheduleBlock scheduleBlock)
		{
			dataManagerRef.ScheduleBlockRepositoryRef.AddAndSaveBlock(scheduleBlock);
			return Redirect("~/schedule");
		}

		public IActionResult DeleteScheduleBlock(Guid blockID, DateTime dateToBack)
		{
			dataManagerRef.ScheduleBlockRepositoryRef.DeleteBlock(blockID);
			return ReturnBackToStandartSchedule(dateToBack);
		}
	}
}
