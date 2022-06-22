using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Areas.Methodist.Model;
using Application.Domain;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Areas.Methodist.Controllers
{
	[Area("Methodist")]
	public class GroupController : Controller
	{
		private readonly DataManager dataManagerRef;

		public GroupController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult AddGroup()
		{
			GroupModel groupModel = new GroupModel();
			groupModel.Group = new Group();
			groupModel.SubjectsId = new List<string>();
			groupModel.Subjects = new SelectList(dataManagerRef.SubjectRepositoryRef.GetAllSubjects(), "Id", "Name");
			return View(groupModel);
		}

		public IActionResult EditGroup(Guid groupID)
		{
			GroupModel groupModel = new GroupModel();
			groupModel.Group = dataManagerRef.GroupRepositoryRef.GetGroupById(groupID);
			groupModel.SubjectsId = dataManagerRef.GroupSubjectRepositoryRef.GetSubjectsInGroup(groupID).Select(x => x.Id.ToString()).ToList();
			groupModel.Subjects = new SelectList(dataManagerRef.SubjectRepositoryRef.GetAllSubjects(), "Id", "Name");
			return View("AddGroup", groupModel);
		}

		[HttpPost]
		public IActionResult Save(GroupModel model)
		{
			if (model.Group.Id == default)
				model.Group.Id = Guid.NewGuid();

			dataManagerRef.GroupRepositoryRef.AddAndSaveGroup(model.Group);

			List<GroupSubject> hadGroupSubjects = dataManagerRef.GroupSubjectRepositoryRef.GetAllGroupSubjects().Where(x => x.GroupId == model.Group.Id).ToList();
			List<GroupSubject> givenGroupSubjects = new List<GroupSubject>();
			for (int i = 0; i < model.SubjectsId.Count; i++)
			{
				givenGroupSubjects.Add(new GroupSubject
				{
					Id = Guid.NewGuid(),
					SubjectId = new Guid(model.SubjectsId[i]),
					GroupId = model.Group.Id
				});
			}
			dataManagerRef.GroupSubjectRepositoryRef.EditSubjectsInGroup(givenGroupSubjects, hadGroupSubjects);

			List<Subject> subjectsInGroup = dataManagerRef.GroupSubjectRepositoryRef.GetSubjectsInGroup(model.Group.Id).ToList();
			List<Domain.Entities.Student> studentsInGroup = dataManagerRef.GroupRepositoryRef.GetStudentsInGroup(model.Group.Id);
			for (int i = 0; i < studentsInGroup.Count; i++)
			{
				List<StudentsEstimates> choosenStudentSubjects = new List<StudentsEstimates>();
				for (int j = 0; j < subjectsInGroup.Count; j++)
				{
					choosenStudentSubjects.Add(new StudentsEstimates
					{
						Id = Guid.NewGuid(),
						StudentId = studentsInGroup[i].Id,
						SubjectId = subjectsInGroup[j].Id
					});
				}
				List<StudentsEstimates> hadStudentSubjects = dataManagerRef.StudentsEstimatesRepositoryRef.GetAllEstimatesInStudent(studentsInGroup[i].Id).ToList();
				dataManagerRef.StudentsEstimatesRepositoryRef.EditSubjectsInStudent(choosenStudentSubjects, hadStudentSubjects);
			}
			return RedirectToAction("Index", "Home");
		}

		public IActionResult DeleteGroup(Guid groupID)
		{
			dataManagerRef.GroupRepositoryRef.DeleteGroup(groupID);
			return RedirectToAction("Index", "Home");
		}
	}
}
