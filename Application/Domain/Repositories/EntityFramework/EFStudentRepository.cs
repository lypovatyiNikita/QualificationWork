using Application.Domain.Entities;
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
	public class EFStudentRepository : IStudentRepository
	{
		private readonly AppDbContext AppDbContextRef;
		private readonly IUniversityUserRepository universityUserRepositoryRef;

		public EFStudentRepository(AppDbContext context, IUniversityUserRepository universityUserRepository)
		{
			AppDbContextRef = context;
			universityUserRepositoryRef = universityUserRepository;
		}

		public IQueryable<Student> GetAllStudents()
		{
			return AppDbContextRef.Students.Include(x => x.StudentUser);
		}

		public Student GetStudentById(Guid? id)
		{
			return AppDbContextRef.Students.Include(x => x.StudentUser).First(x => x.Id == id);
		}

		public Student GetStudentByUserId(string userId)
		{
			return AppDbContextRef.Students.Include(x => x.StudentUser).First(x => x.StudentId == userId);
		}

		public void AddAndSaveStudent(Student newStudent)
		{
			try
			{
				universityUserRepositoryRef.AddAndSaveUser(newStudent.StudentUser);
				newStudent.StudentId = newStudent.StudentUser.Id;
				if (!AppDbContextRef.Students.Any(x => x.Id == newStudent.Id))
					AppDbContextRef.Entry(newStudent).State = EntityState.Added;
				else
					AppDbContextRef.Entry(newStudent).State = EntityState.Modified;
				AppDbContextRef.SaveChanges();
			}
			catch (Exception e)
			{

			};
		}

		public void DeleteStudent(Guid id)
		{
			string userId = GetStudentById(id).StudentId;
			AppDbContextRef.Students.Remove(AppDbContextRef.Students.First(x => x.Id == id));
			universityUserRepositoryRef.DeleteUser(userId);
			AppDbContextRef.SaveChanges();
		}
	}
}
