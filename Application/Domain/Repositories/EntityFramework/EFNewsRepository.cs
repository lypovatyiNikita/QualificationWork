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
	public class EFNewsRepository : INewsRepository
	{
		private readonly AppDbContext AppDbContextRef;

		public EFNewsRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IQueryable<NewsBlock> GetAllNews()
		{
			return AppDbContextRef.NewsBlock;
		}

		public NewsBlock GetNewsById(Guid ID)
		{
			return AppDbContextRef.NewsBlock.FirstOrDefault(x => x.Id == ID);
		}

		public void AddAndSaveNewNew(NewsBlock newNewsBlock)
		{
			if (newNewsBlock.Id == default)
				AppDbContextRef.Entry(newNewsBlock).State = EntityState.Added;
			else
				AppDbContextRef.Entry(newNewsBlock).State = EntityState.Modified;
			AppDbContextRef.SaveChanges();
		}

		public void DeleteNew(Guid newId)
		{
			AppDbContextRef.NewsBlock.Remove(new NewsBlock() { Id = newId });
			AppDbContextRef.SaveChanges();
		}
	}
}
