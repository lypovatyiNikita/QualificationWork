using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Areas.Methodist.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Areas.Methodist.Controllers
{
	[Area("Methodist")]
	public class HomeController : Controller
	{
		private readonly DataManager dataManagerRef;

		public HomeController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult Index()
		{
			MethodistModel model = new MethodistModel()
			{
				Students = new SelectList(dataManagerRef.StudentRepositoryRef.GetAllStudents(), "Id", "StudentUser"),
				Teachers = new SelectList(dataManagerRef.TeacherRepositoryRef.GetAllTeachers(), "Id", "TeacherUser"),
				StudentGroups = new SelectList(dataManagerRef.GroupRepositoryRef.GetAllGroups(), "Id", "Name"),
				Subjects = new SelectList(dataManagerRef.SubjectRepositoryRef.GetAllSubjects(), "Id", "Name")
			};
			return View(model);
		}
	}
}
