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

		public IQueryable<TeacherSubject> GetAllTeacherSubjectsByTeacherId(Guid teacherId)
		{
			return AppDbContextRef.TeacherSubjects.Where(x => x.TeacherId == teacherId).Include(x => x.Teacher).Include(x => x.Subject);
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

		public void EditSubjectsInTeacher(List<TeacherSubject> choosenTeacherSubjects, List<TeacherSubject> hadTeacherSubjects)
		{
			List<TeacherSubject> newTeacherSubjects = new List<TeacherSubject>();
			List<TeacherSubject> deletedTeacherSubjects = new List<TeacherSubject>();
			for (int i = 0; i < choosenTeacherSubjects.Count; i++)
			{
				if(!IsContainsValueInList(hadTeacherSubjects, choosenTeacherSubjects[i]))
				{
					newTeacherSubjects.Add(choosenTeacherSubjects[i]);
				}
			}
			for (int i = 0; i < hadTeacherSubjects.Count; i++)
			{
				if(!IsContainsValueInList(choosenTeacherSubjects, hadTeacherSubjects[i]) && !IsContainsValueInList(newTeacherSubjects, hadTeacherSubjects[i]))
				{
					deletedTeacherSubjects.Add(hadTeacherSubjects[i]);
				}
			}
			for (int i = 0; i < deletedTeacherSubjects.Count; i++)
			{
				AppDbContextRef.TeacherSubjects.Remove(deletedTeacherSubjects[i]);
			}
			AppDbContextRef.SaveChanges();
			AddAndSaveTeacherSubjects(newTeacherSubjects);
		}

		private bool IsContainsValueInList(List<TeacherSubject> list, TeacherSubject value)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].SubjectId == value.SubjectId && list[i].TeacherId == value.TeacherId)
					return true;
			}
			return false;
		}
	}
}
