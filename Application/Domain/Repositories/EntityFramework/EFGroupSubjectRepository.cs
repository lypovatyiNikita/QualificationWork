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
	public class EFGroupSubjectRepository : IGroupSubjectRepository
	{
		private readonly AppDbContext AppDbContextRef;

		public EFGroupSubjectRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IQueryable<GroupSubject> GetAllGroupSubjects()
		{
			return AppDbContextRef.GroupSubjects.Include(x => x.Group).Include(x => x.Subject);
		}

		public IQueryable<Subject> GetSubjectsInGroup(Guid groupId)
		{
			return GetAllGroupSubjects().Include(x => x.Group).Include(x => x.Subject).Where(x => x.GroupId == groupId).Select(x => x.Subject);
		}

		public void AddAndSaveGroupsWithSubjects(List<GroupSubject> groupSubjects)
		{
			throw new NotImplementedException();
		}
	}
}
