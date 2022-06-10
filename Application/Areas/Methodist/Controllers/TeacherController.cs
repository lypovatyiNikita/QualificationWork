using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Areas.Methodist.Model;
using Application.Domain;
using Application.Domain.Entities;
using Application.Domain.Repositories.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Application.Areas.Methodist.Controllers
{
	[Area("Methodist")]
	public class TeacherController : Controller
	{
		private readonly DataManager dataManagerRef;

		public TeacherController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult AddTeacher()
		{
			IQueryable<Subject> subjects = dataManagerRef.SubjectRepositoryRef.GetAllSubjects();
			List<string> subjectsId = subjects.Select(x => x.Id.ToString()).ToList();
			TeacherModel teacherModel = new TeacherModel()
			{
				Teacher = new Domain.Entities.Teacher() { TeacherUser = new UniversityUser() },
				Subjects = subjectsId,
				SubjectsSelect = new SelectList(subjects, "Id", "Name")
			};
			return View(teacherModel);
		}

		public IActionResult EditTeacher(Guid teacherID)
		{
			IQueryable<Subject> subjects = dataManagerRef.SubjectRepositoryRef.GetAllSubjects();
			List<string> subjectsId = subjects.Select(x => x.Id.ToString()).ToList();
			TeacherModel teacherModel = new TeacherModel()
			{
				Teacher = dataManagerRef.TeacherRepositoryRef.GetTeacherById(teacherID),
				Subjects = subjectsId,
				SubjectsSelect = new SelectList(subjects, "Id", "Name")
			};
			return View("AddTeacher", teacherModel);
		}

		[HttpPost]
		public IActionResult Save(TeacherModel model,  string password)
		{
			model.Teacher.TeacherUser.NormalizedUserName = model.Teacher.TeacherUser.UserName.ToUpper();
			if (password != null && password.Length > 6)
				model.Teacher.TeacherUser.PasswordHash = new PasswordHasher<UniversityUser>().HashPassword(null, password);

			if (model.Teacher.Id == default)
				model.Teacher.Id = Guid.NewGuid();

			model.Teacher.TeacherUser.SecurityStamp = string.Empty;
			List<TeacherSubject> choosenTeacherSubjects = new List<TeacherSubject>();
			for (int i = 0; i < model.Subjects.Count(); i++)
			{
				Guid id = Guid.NewGuid();
				if (dataManagerRef.TeacherSubjectRepositoryRef.GetAllTeacherSubjects().Where(x => x.TeacherId == model.Teacher.Id).Where(x => x.SubjectId == new Guid(model.Subjects[i])).Any())
				{
					id = dataManagerRef.TeacherSubjectRepositoryRef.GetAllTeacherSubjects().Where(x => x.TeacherId == model.Teacher.Id).First(x => x.SubjectId == new Guid(model.Subjects[i])).Id;
				}
				choosenTeacherSubjects.Add(new TeacherSubject
				{
					Id = id,
					TeacherId = model.Teacher.Id,
					SubjectId = new Guid(model.Subjects[i])
				});
			}
			dataManagerRef.TeacherRepositoryRef.AddAndSaveTeacher(model.Teacher);
			dataManagerRef.UniversityUserRoleRepositoryRef.AddAndSaveUserInRole(new IdentityUserRole<string> { UserId = model.Teacher.TeacherId, RoleId = EFRoleRepository.TEACHER_ROLE_ID });
			dataManagerRef.TeacherSubjectRepositoryRef.AddAndSaveTeacherSubjects(choosenTeacherSubjects);
			return RedirectToAction("Index", "Home");
		}

		public IActionResult DeleteTeacher(Guid teacherID)
		{
			dataManagerRef.TeacherRepositoryRef.DeleteTeacher(teacherID);
			return RedirectToAction("Index", "Home");
		}
	}
}
