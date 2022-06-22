using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface IGroupRepository
    {
        IQueryable<Group> GetAllGroups();
        Group GetGroupById(Guid id);
        List<Student> GetStudentsInGroup(Guid groupId);
        void AddAndSaveGroup(Group newGroup);
        void DeleteGroup(Guid id);
    }
}
