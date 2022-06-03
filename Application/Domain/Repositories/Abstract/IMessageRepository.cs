using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Entities;

namespace Application.Domain.Repositories.Abstract
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetAllMessagesInUser(string userID);
        void AddAndSaveMessage(Message newMessage);
        void DeleteMessage(Guid messageID);
    }
}
