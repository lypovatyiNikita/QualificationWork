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
	public class EFMessageRepository : IMessageRepository
	{
		private readonly AppDbContext AppDbContextRef;

		public EFMessageRepository(AppDbContext context)
		{
			AppDbContextRef = context;
		}

		public IQueryable<Message> GetAllMessagesInUser(string userID)
		{
			return AppDbContextRef.Message.Where(x => x.NameId == userID);
		}

		public void AddAndSaveMessage(Message newMessage)
		{
			if (newMessage.Id == default)
				AppDbContextRef.Entry(newMessage).State = EntityState.Added;
			else
				AppDbContextRef.Entry(newMessage).State = EntityState.Modified;
			AppDbContextRef.SaveChanges();
		}

		public void DeleteMessage(Guid messageID)
		{
			AppDbContextRef.Message.Remove(new Message() { Id = messageID });
			AppDbContextRef.SaveChanges();
		}
	}
}
