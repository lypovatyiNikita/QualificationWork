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
    public class EFScheduleBlockRepository: IScheduleBlockRepository
    {
		private readonly AppDbContext AppDbContextRef;

		public EFScheduleBlockRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IQueryable<ScheduleBlock> GetAllBlocks()
		{
			return AppDbContextRef.ScheduleBlock.Include(x => x.Group).Include(x => x.Teacher).Include(x => x.Teacher.TeacherUser);
		}

		public ScheduleBlock GetBlockById(Guid id)
		{
			return AppDbContextRef.ScheduleBlock.First(x => x.Id == id);
		}

		public void AddAndSaveBlock(ScheduleBlock newBlock)
		{
			if (newBlock.Id == default)
				AppDbContextRef.Entry(newBlock).State = EntityState.Added;
			else
				AppDbContextRef.Entry(newBlock).State = EntityState.Modified;
			AppDbContextRef.SaveChanges();
		}

		public void DeleteBlock(Guid id)
		{
			AppDbContextRef.ScheduleBlock.Remove(new ScheduleBlock() { Id = id });
			AppDbContextRef.SaveChanges();
		}
	}
}
