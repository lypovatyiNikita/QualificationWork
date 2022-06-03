using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Domain;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Controllers
{
	[Authorize]
	public class ChatController : Controller
	{
		private readonly DataManager dataManagerRef;

		public ChatController(DataManager dataManager)
		{
			dataManagerRef = dataManager;
		}

		public IActionResult Index()
		{
			return View(new SelectList(dataManagerRef.StudentRepositoryRef.GetAllStudents(), "StudentId", "StudentUser"));
		}
	}
}
