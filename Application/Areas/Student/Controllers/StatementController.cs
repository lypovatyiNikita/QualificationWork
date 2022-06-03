using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Areas.Student.Model;
using Application.Domain;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Areas.Student.Controllers
{
	[Area("Student")]
	public class StatementController : Controller
	{
		private readonly DataManager dataManagerRef;

		public StatementController(DataManager dataManager)
		{
			dataManagerRef = dataManager;

		}

		public IActionResult Statement()
		{
			string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
			Application.Domain.Entities.Student student = dataManagerRef.StudentRepositoryRef.GetStudentByUserId(userId);
			IQueryable <StudentsEstimates> estimates = dataManagerRef.StudentsEstimatesRepositoryRef.GetAllEstimatesInStudent(student.Id);
			return View(estimates);
		}
	}
}
