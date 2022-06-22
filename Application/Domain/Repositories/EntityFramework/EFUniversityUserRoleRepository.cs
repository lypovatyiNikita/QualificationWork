using Application.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.EntityFramework
{
	public class EFUniversityUserRoleRepository : IUniversityUserRoleRepository
	{
		private readonly AppDbContext AppDbContextRef;

		public EFUniversityUserRoleRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IdentityUserRole<string> GetUserRoleById(string userid)
		{
			return AppDbContextRef.UserRoles.First(x => x.UserId == userid);
		}

		public IdentityUserRole<string> GetUserRoleByUserIdAndRoleId(string userId, string roleId)
		{
			IQueryable<IdentityUserRole<string>> identityUserRoles = AppDbContextRef.UserRoles.Where(x => x.UserId == userId);
			return identityUserRoles?.FirstOrDefault(x => x.RoleId == roleId);
		}

		public void AddAndSaveUserInRole(IdentityUserRole<string> newUserRole)
		{
			if (!AppDbContextRef.UserRoles.Where(x => x.UserId == newUserRole.UserId).Any(x => x.RoleId == newUserRole.RoleId))
				AppDbContextRef.Entry(newUserRole).State = EntityState.Added;
			else
			{
				AppDbContextRef.Entry(newUserRole).State = EntityState.Modified;
			}
			AppDbContextRef.SaveChanges();
		}

		public void DeleteUserInRole(string userid, string roleId)
		{
			AppDbContextRef.UserRoles.Remove(AppDbContextRef.UserRoles.Where(x => x.UserId == userid).First(x => x.RoleId == roleId));
			AppDbContextRef.SaveChanges();
		}
	}
}
