using Application.Domain.Entities;
using Application.Domain.Repositories.Abstract;
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
	}
}
