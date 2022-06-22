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

namespace Application.Areas.Methodist.Controllers
{
	[Area("Methodist")]
	public class StudentController : Controller
	{
		private readonly DataManager dataManagerRef;

		public StudentController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult AddStudent()
		{
			ViewBag.Groups = new SelectList(dataManagerRef.GroupRepositoryRef.GetAllGroups().ToList(), "Id", "Name");
			return View(new StudentModel
			{
				Student = new Domain.Entities.Student(),
				UniversityUser = new UniversityUser(),
				Groups = new SelectList(dataManagerRef.GroupRepositoryRef.GetAllGroups().ToList(), "Id", "Name")
			});
		}

		public IActionResult EditStudent(Guid studentID)
		{
			Domain.Entities.Student student = dataManagerRef.StudentRepositoryRef.GetStudentById(studentID);
			List<Group> groups = dataManagerRef.GroupRepositoryRef.GetAllGroups().ToList();
			return View("AddStudent", new StudentModel
			{
				Student = student,
				UniversityUser = dataManagerRef.UniversityUserRepositoryRef.GetUserById(student.StudentId),
				Groups = new SelectList(groups, "Id", "Name", groups.First(x => x.Id == student.GroupId))
			});
		}

		public IActionResult Save(StudentModel studentModel, string password, Guid groupId)
		{
			studentModel.UniversityUser.NormalizedUserName = studentModel.UniversityUser.UserName.ToUpper();
			if (password != null && password.Length > 6)
				studentModel.UniversityUser.PasswordHash = new PasswordHasher<UniversityUser>().HashPassword(null, password);
			else if (password == null && studentModel.Student.Id != default)
				studentModel.UniversityUser.PasswordHash = dataManagerRef.StudentRepositoryRef.GetPasswordByStudentId(studentModel.Student.Id);

			if (studentModel.Student.Id == default)
				studentModel.Student.Id = Guid.NewGuid();

			if (studentModel.UniversityUser.Id == default)
			{
				studentModel.UniversityUser.Id = Guid.NewGuid().ToString();
			}

			if (studentModel.Student.StudentId == null)
			{
				studentModel.Student.StudentId = studentModel.UniversityUser.Id;
			}

			studentModel.UniversityUser.SecurityStamp = string.Empty;
			studentModel.Student.GroupId = groupId;
			dataManagerRef.UniversityUserRepositoryRef.AddAndSaveUser(studentModel.UniversityUser);
			dataManagerRef.StudentRepositoryRef.AddAndSaveStudent(studentModel.Student);

			IdentityUserRole<string> editedUserRole = dataManagerRef.UniversityUserRoleRepositoryRef.GetUserRoleByUserIdAndRoleId(studentModel.Student.StudentId, EFRoleRepository.STUDENT_ROLE_ID);
			if (editedUserRole == null)
				dataManagerRef.UniversityUserRoleRepositoryRef.AddAndSaveUserInRole(new IdentityUserRole<string> { UserId = studentModel.Student.StudentId, RoleId = EFRoleRepository.STUDENT_ROLE_ID });

			if (dataManagerRef.StudentsEstimatesRepositoryRef.GetAllEstimatesInStudent(studentModel.Student.Id) == null || dataManagerRef.StudentsEstimatesRepositoryRef.GetAllEstimatesInStudent(studentModel.Student.Id).Count() == 0)
			{
				List<Subject> groupSubjects = dataManagerRef.GroupSubjectRepositoryRef.GetSubjectsInGroup(studentModel.Student.GroupId).ToList();
				List<StudentsEstimates> studentEstimates = new List<StudentsEstimates>();
				for (int i = 0; i < groupSubjects.Count; i++)
				{
					var id = Guid.NewGuid();
					studentEstimates.Add(new StudentsEstimates
					{
						Id = id,
						StudentId = studentModel.Student.Id,
						SubjectId = groupSubjects[i].Id
					});
				}
				dataManagerRef.StudentsEstimatesRepositoryRef.AddOrEdirEstimates(studentEstimates);
			}

			return RedirectToAction("Index", "Home");
		}

		public IActionResult DeleteStudent(Guid studentID)
		{
			dataManagerRef.StudentRepositoryRef.DeleteStudent(studentID);
			return RedirectToAction("Index", "Home");
		}
	}
}
