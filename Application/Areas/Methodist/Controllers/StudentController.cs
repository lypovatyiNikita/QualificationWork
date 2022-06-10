using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			return View(new Domain.Entities.Student() { StudentUser = new UniversityUser() });
		}

		public IActionResult EditStudent(Guid studentID)
		{
			Domain.Entities.Student student = dataManagerRef.StudentRepositoryRef.GetStudentById(studentID);
			student.StudentUser = dataManagerRef.UniversityUserRepositoryRef.GetUserById(student.StudentId);
			List<Group> groups = dataManagerRef.GroupRepositoryRef.GetAllGroups().ToList();
			ViewBag.Groups = new SelectList(groups, "Id", "Name", groups.First(x => x.Id == student.GroupId));
			return View("AddStudent", student);
		}

		public IActionResult Save(Domain.Entities.Student student, string password, Guid groupId)
		{
			student.StudentUser.NormalizedUserName = student.StudentUser.UserName.ToUpper();
			if (password!=null && password.Length > 6)
				student.StudentUser.PasswordHash = new PasswordHasher<UniversityUser>().HashPassword(null, password);

			if (student.Id == default)
				student.Id = Guid.NewGuid();

			student.StudentUser.SecurityStamp = string.Empty;
			student.GroupId = groupId;
			student.StudentId = student.StudentUser.Id;
			dataManagerRef.StudentRepositoryRef.AddAndSaveStudent(student);
			dataManagerRef.UniversityUserRoleRepositoryRef.AddAndSaveUserInRole(new IdentityUserRole<string> { UserId = student.StudentId, RoleId = EFRoleRepository.STUDENT_ROLE_ID });
			return RedirectToAction("Index", "Home");
		}

		public IActionResult DeleteStudent(Guid studentID)
		{
			dataManagerRef.StudentRepositoryRef.DeleteStudent(studentID);
			return RedirectToAction("Index", "Home");
		}
	}
}
