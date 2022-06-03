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
	public class EFTeacherSubjectRepository : ITeacherSubjectRepository
	{
		private readonly AppDbContext AppDbContextRef;

		public EFTeacherSubjectRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IQueryable<Subject> GetSubjectsInTeacher(Guid teacherId)
		{
			return AppDbContextRef.TeacherSubjects.Where(x => x.TeacherId == teacherId).Include(x => x.Subject).Select(x => x.Subject);
		}

		public TeacherSubject GetTeacherSubjectById(Guid id)
		{
			return AppDbContextRef.TeacherSubjects.First(x => x.Id == id);
		}

		public void AddAndSaveTeacherSubject(TeacherSubject newTeacherSubject)
		{
			if (newTeacherSubject.Id == default)
				AppDbContextRef.Entry(newTeacherSubject).State = EntityState.Added;
			else
				AppDbContextRef.Entry(newTeacherSubject).State = EntityState.Modified;
			AppDbContextRef.SaveChanges();
		}

		public void AddAndSaveTeacherSubjects(List<TeacherSubject> newTeacherSubjects)
		{
			foreach (var item in newTeacherSubjects)
			{
				if (!AppDbContextRef.TeacherSubjects.Where(x => x.SubjectId == item.SubjectId).Where(x => x.TeacherId == item.TeacherId).Any()) 
					AppDbContextRef.Entry(item).State = EntityState.Added;
				else
					AppDbContextRef.Entry(item).State = EntityState.Modified;
			}
			AppDbContextRef.SaveChanges();
		}

		public void DeleteTeacherSubject(Guid id)
		{
			AppDbContextRef.TeacherSubjects.Remove(AppDbContextRef.TeacherSubjects.First(x => x.Id == id));
			AppDbContextRef.SaveChanges();
		}

		public IQueryable<TeacherSubject> GetAllTeacherSubjects()
		{
			return AppDbContextRef.TeacherSubjects;
		}
	}
}
