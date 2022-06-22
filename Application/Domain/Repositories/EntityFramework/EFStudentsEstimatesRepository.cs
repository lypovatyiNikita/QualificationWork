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
	public class EFStudentsEstimatesRepository : IStudentsEstimatesRepository
	{
		private readonly AppDbContext AppDbContextRef;

		public EFStudentsEstimatesRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IQueryable<StudentsEstimates> GetAllEstimatesInStudent(Guid studentId)
		{
			return AppDbContextRef.StudentsEstimates.Include(x => x.Student).Include(x => x.Subject).Where(x => x.StudentId == studentId);
		}

		public List<StudentsEstimates> GetAllEstimatesWithSubjects(List<Subject> subjects)
		{
			List<StudentsEstimates> gettedList = AppDbContextRef.StudentsEstimates.Include(x => x.Subject).Include(x => x.Student).ThenInclude(x => x.StudentUser).Include(x => x.Student.Group).ToList();
			List<StudentsEstimates> answer = new List<StudentsEstimates>();
			for (int i = 0; i < subjects.Count; i++)
			{
				for (int j = 0; j < gettedList.Count; j++)
				{
					if (gettedList[j].Subject == subjects[i])
					{
						answer.Add(gettedList[j]);
					}
				}
			}
			answer.OrderBy(x => x.Subject);
			return answer;
		}

		public void AddOrEdirEstimates(List<StudentsEstimates> studentsEstimates)
		{
			foreach (var item in studentsEstimates)
			{
				if (!AppDbContextRef.StudentsEstimates.Any(x => x.Id == item.Id))
					AppDbContextRef.Entry(item).State = EntityState.Added;
				else
					AppDbContextRef.Entry(item).State = EntityState.Modified;
			}
			AppDbContextRef.SaveChanges();
		}

		public void EditSubjectsInStudent(List<StudentsEstimates> choosenSubjects, List<StudentsEstimates> hadSubjects)
		{
			List<StudentsEstimates> newTeacherSubjects = new List<StudentsEstimates>();
			List<StudentsEstimates> deletedTeacherSubjects = new List<StudentsEstimates>();
			for (int i = 0; i < choosenSubjects.Count; i++)
			{
				if (!IsContainsValueInList(hadSubjects, choosenSubjects[i]))
				{
					newTeacherSubjects.Add(choosenSubjects[i]);
				}
			}
			for (int i = 0; i < hadSubjects.Count; i++)
			{
				if (!IsContainsValueInList(choosenSubjects, hadSubjects[i]) && !IsContainsValueInList(newTeacherSubjects, hadSubjects[i]))
				{
					deletedTeacherSubjects.Add(hadSubjects[i]);
				}
			}
			for (int i = 0; i < deletedTeacherSubjects.Count; i++)
			{
				AppDbContextRef.StudentsEstimates.Remove(deletedTeacherSubjects[i]);
			}
			AppDbContextRef.SaveChanges();
			AddOrEdirEstimates(newTeacherSubjects);
		}

		private bool IsContainsValueInList(List<StudentsEstimates> list, StudentsEstimates value)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].SubjectId == value.SubjectId && list[i].SubjectId == value.SubjectId)
					return true;
			}
			return false;
		}
	}
}
