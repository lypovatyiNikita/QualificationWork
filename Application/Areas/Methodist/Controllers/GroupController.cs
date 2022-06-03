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
			groupModel.Groups = new SelectList(dataManagerRef.GroupRepositoryRef.GetAllGroups(), "Id", "Name");
			groupModel.SubjectsId = dataManagerRef.SubjectRepositoryRef.GetAllSubjects().Select(x => x.Id.ToString()).ToList();
			groupModel.Subjects = new SelectList(groupModel.SubjectsId, "Id", "Name");
			return View(groupModel);
		}

		public IActionResult EditGroup(Guid groupID)
		{
			GroupModel groupModel = new GroupModel();
			groupModel.Group = dataManagerRef.GroupRepositoryRef.GetGroupById(groupID);
			groupModel.Groups = new SelectList(dataManagerRef.GroupRepositoryRef.GetAllGroups(), "Id", "Name");
			groupModel.SubjectsId = dataManagerRef.SubjectRepositoryRef.GetAllSubjects().Select(x => x.Id.ToString()).ToList();
			return View("AddGroup", groupModel);
		}

		[HttpPost]
		public IActionResult Save(GroupModel model)
		{
			Group givenGroup = dataManagerRef.GroupRepositoryRef.GetGroupById(model.Group.Id);
			if (givenGroup == null || !givenGroup.Equals(model.Group))
			{
				dataManagerRef.GroupRepositoryRef.AddAndSaveGroup(model.Group);
				List<GroupSubject> newGroupSubjects = new List<GroupSubject>();
				for (int i = 0; i < model.SubjectsId.Count; i++)
				{
					if (dataManagerRef.GroupSubjectRepositoryRef.GetSubjectsInGroup(model.Group.Id).First(x => x.Id == new Guid(model.SubjectsId[i]))==null) 
					{
						newGroupSubjects.Add(new GroupSubject
						{
							Id = Guid.NewGuid(),
							SubjectId = new Guid(model.SubjectsId[i]),
							GroupId = model.Group.Id
						});
					}
				}
				dataManagerRef.GroupSubjectRepositoryRef.AddAndSaveGroupsWithSubjects(newGroupSubjects);
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
