using Application.Domain.Entities;
using Application.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.EntityFramework
{
	public class EFTeacherRepository : ITeacherRepository
	{
		private readonly AppDbContext AppDbContextRef;
		private readonly IUniversityUserRepository universityUserRepositoryRef;

		public EFTeacherRepository(AppDbContext context, IUniversityUserRepository universityUserRepository)
		{
			AppDbContextRef = context;
			universityUserRepositoryRef = universityUserRepository;
		}

		public IQueryable<Teacher> GetAllTeachers()
		{
			return AppDbContextRef.Teachers.Include(x => x.TeacherUser);
		}

		public Teacher GetTeacherById(Guid id)
		{
			return AppDbContextRef.Teachers.Include(x => x.TeacherUser).First(x => x.Id == id);
		}

		public Teacher GetTeacherByUserId(string userId)
		{
			return AppDbContextRef.Teachers.Include(x => x.TeacherUser).First(x => x.TeacherId == userId);
		}

		public void AddAndSaveTeacher(Teacher newTeacher)
		{
			try
			{
				universityUserRepositoryRef.AddAndSaveUser(newTeacher.TeacherUser);
				if (AppDbContextRef.Teachers.Any(x => x == newTeacher))
					AppDbContextRef.Entry(newTeacher).State = EntityState.Added;
				else
					AppDbContextRef.Entry(newTeacher).State = EntityState.Modified;
				AppDbContextRef.SaveChanges();
			}
			catch (Exception e)
			{

			}
		}

		public void DeleteTeacher(Guid id)
		{
			string userId = GetTeacherById(id).TeacherId;
			AppDbContextRef.Teachers.Remove(AppDbContextRef.Teachers.First(x => x.Id == id));
			universityUserRepositoryRef.DeleteUser(userId);
			AppDbContextRef.SaveChanges();
		}
	}
}
