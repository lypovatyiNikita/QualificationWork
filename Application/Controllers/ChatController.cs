using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Domain;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Domain.Repositories.EntityFramework;

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
			List<ChatViewModel> model = new List<ChatViewModel>();
			List<UniversityUser> allUsers = dataManagerRef.UniversityUserRepositoryRef.GetAllUniversityUsers().ToList();
			for (int i = 0; i < allUsers.Count; i++)
			{
				if (User.IsInRole(AllRoles.MethodistRole))
				{
					if (dataManagerRef.UniversityUserRoleRepositoryRef.GetUserRoleById(allUsers[i].Id).RoleId == EFRoleRepository.STUDENT_ROLE_ID)
					{
						model.Add(new ChatViewModel { UserName = allUsers[i].ToString(), SendUserID = allUsers[i].Id, userType = "Student" });
					}
					else if (dataManagerRef.UniversityUserRoleRepositoryRef.GetUserRoleById(allUsers[i].Id).RoleId == EFRoleRepository.TEACHER_ROLE_ID)
						model.Add(new ChatViewModel { UserName = allUsers[i].ToString(), SendUserID = allUsers[i].Id, userType = "Teacher" });
				}
				else if (User.IsInRole(AllRoles.StudentRole))
				{
					if (dataManagerRef.UniversityUserRoleRepositoryRef.GetUserRoleById(allUsers[i].Id).RoleId == EFRoleRepository.METHODIST_ROLE_ID)
					{
						model.Add(new ChatViewModel { UserName = allUsers[i].ToString(), SendUserID = allUsers[i].Id, userType = "Methodist" });
					}
					else if (dataManagerRef.UniversityUserRoleRepositoryRef.GetUserRoleById(allUsers[i].Id).RoleId == EFRoleRepository.TEACHER_ROLE_ID)
						model.Add(new ChatViewModel { UserName = allUsers[i].ToString(), SendUserID = allUsers[i].Id, userType = "Teacher" });
				}
				else if (User.IsInRole(AllRoles.TeacherRole))
				{
					if (dataManagerRef.UniversityUserRoleRepositoryRef.GetUserRoleById(allUsers[i].Id).RoleId == EFRoleRepository.METHODIST_ROLE_ID)
					{
						model.Add(new ChatViewModel { UserName = allUsers[i].ToString(), SendUserID = allUsers[i].Id, userType = "Methodist" });
					}
					else if (dataManagerRef.UniversityUserRoleRepositoryRef.GetUserRoleById(allUsers[i].Id).RoleId == EFRoleRepository.STUDENT_ROLE_ID)
						model.Add(new ChatViewModel { UserName = allUsers[i].ToString(), SendUserID = allUsers[i].Id, userType = "Student" });
				}
			}
			model.Sort(CompareDinosByLength);
			return View(model);
		}
        private int CompareDinosByLength(ChatViewModel x, ChatViewModel y)
        {
            if (x.userType == null)
            {
                if (y.userType == null)
                {
                    // If x is null and y is null, they're
                    // equal.
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater.
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y.userType == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the
                    // lengths of the two strings.
                    //
                    int retval = x.userType.Length.CompareTo(y.userType.Length);

                    if (retval != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return retval;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        return x.userType.CompareTo(y.userType);
                    }
                }
            }
        }
    }
}
