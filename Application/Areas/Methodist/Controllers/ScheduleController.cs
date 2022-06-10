using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Areas.Methodist.Model;
using Application.Domain;
using Application.Domain.Entities;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
				AllSheduleBlocks = new SelectList(dataManagerRef.ScheduleBlockRepositoryRef.GetAllBlocks().ToList(), "Id", "Title")
			});
		}

		public IActionResult AddScheduleBlock()
		{
			return View(new ScheduleBlockModel
			{
				BlockRef = new ScheduleBlock(),
				TeachersRef = new SelectList(dataManagerRef.TeacherRepositoryRef.GetAllTeachers(), "Id", "TeacherUser"),
				GroupsRef = new SelectList(dataManagerRef.GroupRepositoryRef.GetAllGroups(), "Id", "Name")
			});
		}

		public IActionResult EditScheduleBlock(Guid blockID)
		{
			ScheduleBlock gettedBlock = dataManagerRef.ScheduleBlockRepositoryRef.GetBlockById(blockID);
			return View("AddScheduleBlock", new ScheduleBlockModel
			{
				BlockRef = gettedBlock,
				TeachersRef = new SelectList(dataManagerRef.TeacherRepositoryRef.GetAllTeachers(), "Id", "TeacherUser", gettedBlock.TeacherId),
				GroupsRef = new SelectList(dataManagerRef.GroupRepositoryRef.GetAllGroups(), "Id", "Name", gettedBlock.GroupId)
			});
		}

		public IActionResult SaveScheduleBlock(ScheduleBlockModel scheduleBlockModel, Guid teacherId, Guid groupId)
		{
			if (teacherId != default)
				scheduleBlockModel.BlockRef.TeacherId = teacherId;
			if (groupId != default)
				scheduleBlockModel.BlockRef.GroupId= groupId;

			dataManagerRef.ScheduleBlockRepositoryRef.AddAndSaveBlock(scheduleBlockModel.BlockRef);
			return Redirect("~/schedule");
		}

		public IActionResult DeleteScheduleBlock(Guid blockID, DateTime dateToBack)
		{
			dataManagerRef.ScheduleBlockRepositoryRef.DeleteBlock(blockID);
			return ReturnBackToStandartSchedule(dateToBack);
		}
	}
}
