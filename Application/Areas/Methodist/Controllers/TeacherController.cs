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
			List<Subject> subjects = dataManagerRef.SubjectRepositoryRef.GetAllSubjects().ToList();
			List<string> subjectsId = new List<string>();
			MultiSelectList subjectsSelect = new MultiSelectList(subjects, "Id", "Name");
			TeacherModel teacherModel = new TeacherModel()
			{
				Teacher = new Domain.Entities.Teacher() { TeacherUser = new UniversityUser() },
				Subjects = subjectsId,
				SubjectsSelect = subjectsSelect
			};
			return View(teacherModel);
		}

		public IActionResult EditTeacher(Guid teacherID)
		{
			List<Subject> subjects = dataManagerRef.SubjectRepositoryRef.GetAllSubjects().ToList();
			List<string> subjectsId = dataManagerRef.TeacherSubjectRepositoryRef.GetSubjectsInTeacher(teacherID).Select(x => x.Id.ToString()).ToList();
			SelectList subjectsSelect = new SelectList(subjects, "Id", "Name");
			TeacherModel teacherModel = new TeacherModel()
			{
				Teacher = dataManagerRef.TeacherRepositoryRef.GetTeacherById(teacherID),
				Subjects = subjectsId,
				SubjectsSelect = subjectsSelect
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
			dataManagerRef.UniversityUserRepositoryRef.AddAndSaveUser(model.Teacher.TeacherUser);
			dataManagerRef.TeacherRepositoryRef.AddAndSaveTeacher(model.Teacher);

			IdentityUserRole<string> editedUserRole = dataManagerRef.UniversityUserRoleRepositoryRef.GetUserRoleByUserIdAndRoleId(model.Teacher.TeacherId, EFRoleRepository.TEACHER_ROLE_ID);
			if (editedUserRole == default)
				dataManagerRef.UniversityUserRoleRepositoryRef.AddAndSaveUserInRole(new IdentityUserRole<string> { UserId = model.Teacher.TeacherId, RoleId = EFRoleRepository.TEACHER_ROLE_ID });

			List<TeacherSubject> teacherSubjects = dataManagerRef.TeacherSubjectRepositoryRef.GetAllTeacherSubjectsByTeacherId(model.Teacher.Id).ToList();
			List<TeacherSubject> choosenTeacherSubjects = new List<TeacherSubject>();
			if (model.Subjects != null)
			{
				for (int i = 0; i < model.Subjects.Count; i++)
				{
					Guid id = Guid.NewGuid();
					choosenTeacherSubjects.Add(new TeacherSubject
					{
						Id = id,
						TeacherId = model.Teacher.Id,
						SubjectId = new Guid(model.Subjects[i])
					});
				}
			}
			dataManagerRef.TeacherSubjectRepositoryRef.EditSubjectsInTeacher(choosenTeacherSubjects, teacherSubjects);

			return RedirectToAction("Index", "Home");
		}

		public void Deselect(TeacherModel model)
		{
			model.Subjects = new List<string>();
		}

		public IActionResult DeleteTeacher(Guid teacherID)
		{
			dataManagerRef.TeacherRepositoryRef.DeleteTeacher(teacherID);
			return RedirectToAction("Index", "Home");
		}
	}
}
