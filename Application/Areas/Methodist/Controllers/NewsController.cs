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
	public class NewsController : Controller
	{
		private readonly DataManager dataManagerRef;

		public NewsController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult AddNew()
		{
			return View(new NewsBlock());
		}

		public IActionResult EditNew(Guid newID)
		{
			return View("AddNew", dataManagerRef.NewsRepositoryRef.GetNewsById(newID));
		}

		public IActionResult SaveNew(NewsBlock newsBlock)
		{
			dataManagerRef.NewsRepositoryRef.AddAndSaveNewNew(newsBlock);
			return Redirect("~/news");
		}

		public IActionResult DeleteNew(Guid needBlockID)
		{
			dataManagerRef.NewsRepositoryRef.DeleteNew(needBlockID);
			return Redirect("~/news");
		}
	}
}
