using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Entities;
using Application.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Application.Domain.Repositories.EntityFramework
{
	public class EFScheduleRepository : IScheduleRepository
	{
		private readonly AppDbContext AppDbContextRef;

		public EFScheduleRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IQueryable<Schedule> GetAllSchedules()
		{
			return AppDbContextRef.Schedule;
		}

		public IQueryable<Schedule> GetAllSheduleByDate(DateTime needDateTime)
		{
			return AppDbContextRef.Schedule.Include(x => x.Block).Where(x => x.DateOfBlock == needDateTime);
		}

		public Schedule GetScheduleById(Guid ID)
		{
			return AppDbContextRef.Schedule.FirstOrDefault(x => x.Id == ID);
		}

		public void AddAndSaveBlock(Schedule newSchedule)
		{
			if (newSchedule.Id == default)
				AppDbContextRef.Entry(newSchedule).State = EntityState.Added;
			else
				AppDbContextRef.Entry(newSchedule).State = EntityState.Modified;
			AppDbContextRef.SaveChanges();
		}

		public void DeleteBlock(Guid id)
		{
			AppDbContextRef.Schedule.Remove(new Schedule() { Id = id });
			AppDbContextRef.SaveChanges();
		}

	}
}
