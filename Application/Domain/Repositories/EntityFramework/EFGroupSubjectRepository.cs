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

		public IQueryable<Subject> GetSubjectsInGroup(Guid? groupId)
		{
			return GetAllGroupSubjects().Include(x => x.Group).Include(x => x.Subject).Where(x => x.GroupId == groupId).Select(x => x.Subject);
		}

		public void AddAndSaveGroupsWithSubjects(List<GroupSubject> groupSubjects)
		{
			foreach (var item in groupSubjects)
			{
				if (!AppDbContextRef.GroupSubjects.Any(x => x.Id == item.Id))
					AppDbContextRef.Entry(item).State = EntityState.Added;
				else
					AppDbContextRef.Entry(item).State = EntityState.Modified;
			}
			AppDbContextRef.SaveChanges();
		}

		public void EditSubjectsInGroup(List<GroupSubject> choosenSubjects, List<GroupSubject> hadSubjects)
		{
			List<GroupSubject> newGroupSubjects = new List<GroupSubject>();
			List<GroupSubject> deletedGroupSubjects = new List<GroupSubject>();
			for (int i = 0; i < choosenSubjects.Count; i++)
			{
				if (!IsContainsValueInList(hadSubjects, choosenSubjects[i]))
				{
					newGroupSubjects.Add(choosenSubjects[i]);
				}
			}
			for (int i = 0; i < hadSubjects.Count; i++)
			{
				if (!IsContainsValueInList(choosenSubjects, hadSubjects[i]) && !IsContainsValueInList(newGroupSubjects, hadSubjects[i]))
				{
					deletedGroupSubjects.Add(hadSubjects[i]);
				}
			}
			for (int i = 0; i < deletedGroupSubjects.Count; i++)
			{
				AppDbContextRef.GroupSubjects.Remove(deletedGroupSubjects[i]);
			}
			AppDbContextRef.SaveChanges();
			AddAndSaveGroupsWithSubjects(newGroupSubjects);
		}

		private bool IsContainsValueInList(List<GroupSubject> list, GroupSubject value)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].SubjectId == value.SubjectId && list[i].GroupId == value.GroupId)
					return true;
			}
			return false;
		}
	}
}
