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
	public class EFGroupRepository : IGroupRepository
	{
		private readonly AppDbContext AppDbContextRef;

		public EFGroupRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IQueryable<Group> GetAllGroups()
		{
			return AppDbContextRef.Groups;
		}

		public Group GetGroupById(Guid id)
		{
			return AppDbContextRef.Groups.First(x => x.Id == id);
		}

		public List<Student> GetStudentsInGroup(Guid groupId)
		{
			return AppDbContextRef.Groups.Include(x => x.Students).First(x => x.Id == groupId).Students;
		}

		public void AddAndSaveGroup(Group newGroup)
		{
			if (!AppDbContextRef.Groups.Any(x => x.Id == newGroup.Id))
				AppDbContextRef.Entry(newGroup).State = EntityState.Added;
			else
				AppDbContextRef.Entry(newGroup).State = EntityState.Modified;
			AppDbContextRef.SaveChanges();
		}

		public void DeleteGroup(Guid id)
		{
			AppDbContextRef.Groups.Remove(new Group() { Id = id });
			AppDbContextRef.SaveChanges();
		}
	}
}
