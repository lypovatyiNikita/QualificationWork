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
	public class EFSubjectRepository : ISubjectRepository
	{
		private readonly AppDbContext AppDbContextRef;

		public EFSubjectRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IQueryable<Subject> GetAllSubjects()
		{
			return AppDbContextRef.Subjects;
		}

		public Subject GetSubjectById(Guid? id)
		{
			return AppDbContextRef.Subjects.First(x => x.Id == id);
		}

		public void AddAndSaveSubject(Subject newSubject)
		{
			if (!AppDbContextRef.Subjects.Any(x => x.Id == newSubject.Id))
				AppDbContextRef.Entry(newSubject).State = EntityState.Added;
			else
				AppDbContextRef.Entry(newSubject).State = EntityState.Modified;
			AppDbContextRef.SaveChanges();
		}

		public void DeleteSubject(Guid subjectId)
		{
			AppDbContextRef.Subjects.Remove(AppDbContextRef.Subjects.First(x => x.Id == subjectId));
			AppDbContextRef.SaveChanges();
		}
	}
}
