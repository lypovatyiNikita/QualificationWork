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
	public class EFUniversityUserRepository : IUniversityUserRepository
	{
		private readonly AppDbContext AppDbContextRef;

		public EFUniversityUserRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IQueryable<UniversityUser> GetAllUniversityUsers()
		{
			return AppDbContextRef.UniversityUser;
		}

		public UniversityUser GetUserById(string id)
		{
			return AppDbContextRef.UniversityUser.First(x => x.Id == id);
		}

		public void AddAndSaveUser(UniversityUser newUser)
		{
			if (!AppDbContextRef.UniversityUser.Any(x => x.Id == newUser.Id))
				AppDbContextRef.Entry(newUser).State = EntityState.Added;
			else
			{
				UniversityUser user = AppDbContextRef.UniversityUser.First(x => x.Id == newUser.Id);
				user.UserName = newUser.UserName;
				user.Name = newUser.Name;
				user.Surname = newUser.Surname;
				user.PasswordHash = newUser.PasswordHash;
				AppDbContextRef.Entry(user).State = EntityState.Modified;
			}
			AppDbContextRef.SaveChanges();
		}

		public void DeleteUser(string id)
		{
			AppDbContextRef.UniversityUser.Remove(AppDbContextRef.UniversityUser.First(x => x.Id == id));
			AppDbContextRef.SaveChanges();
		}
	}
}
