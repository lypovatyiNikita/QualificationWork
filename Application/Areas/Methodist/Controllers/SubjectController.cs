using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Areas.Methodist.Controllers
{
	[Area("Methodist")]
	public class SubjectController : Controller
	{
		private readonly DataManager dataManagerRef;

		public SubjectController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult AddSubject()
		{
			Subject newSubject = new Subject();
			return View(newSubject);
		}

		public IActionResult EditSubject(Guid subjectID)
		{
			Subject givenSubject = dataManagerRef.SubjectRepositoryRef.GetSubjectById(subjectID);
			return View("AddSubject", givenSubject);
		}

		[HttpPost]
		public IActionResult Save(Subject model)
		{
			if (model.Id == default)
				model.Id = Guid.NewGuid();

			dataManagerRef.SubjectRepositoryRef.AddAndSaveSubject(model);
			return RedirectToAction("Index", "Home");
		}

		public IActionResult DeleteSubject(Guid subjectID)
		{
			dataManagerRef.SubjectRepositoryRef.DeleteSubject(subjectID);
			return RedirectToAction("Index", "Home");
		}
	}
}
