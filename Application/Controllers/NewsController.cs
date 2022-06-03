using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
	public class NewsController : Controller
	{
		private readonly DataManager dataManagerRef;

		public NewsController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult News()
		{
			return View(dataManagerRef.NewsRepositoryRef.GetAllNews().OrderByDescending(x => x.CreateDate));
		}

		public IActionResult New(Guid id)
		{
			if (id != default)
			{
				return View("New", dataManagerRef.NewsRepositoryRef.GetNewsById(id));
			}
			return RedirectToAction("News");
		}

		
	}
}
