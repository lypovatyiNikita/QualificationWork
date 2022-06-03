using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Areas.Teacher.Model;
using Application.Domain;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Areas.Teacher.Controllers
{
	[Area("Teacher")]
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
			Domain.Entities.Teacher teacher = dataManagerRef.TeacherRepositoryRef.GetTeacherByUserId(userId);
			List<Subject> subjects = dataManagerRef.TeacherSubjectRepositoryRef.GetSubjectsInTeacher(teacher.Id).ToList();
			List<StudentsEstimates> needStatements = dataManagerRef.StudentsEstimatesRepositoryRef.GetAllEstimatesWithSubjects(subjects);
			return View(needStatements);
		}

		public IActionResult SaveStatement(List<StudentsEstimates> model)
		{
			for (int i = 0; i < model.Count; i++)
			{
				if (model[i].Student == null)
					model[i].Student = dataManagerRef.StudentRepositoryRef.GetStudentById(model[i].StudentId);
				if (model[i].Student.StudentUser == null)
					model[i].Student.StudentUser = dataManagerRef.UniversityUserRepositoryRef.GetUserById(model[i].Student.StudentId);
				if (model[i].Subject == null)
					model[i].Subject = dataManagerRef.SubjectRepositoryRef.GetSubjectById(model[i].SubjectId);
			}
			dataManagerRef.StudentsEstimatesRepositoryRef.AddOrEdirEstimates(model);
			return View("Statement", model);
		}
	}
}
