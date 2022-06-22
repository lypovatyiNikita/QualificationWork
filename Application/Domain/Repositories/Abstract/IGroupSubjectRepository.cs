using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface IGroupSubjectRepository
    {
        IQueryable<GroupSubject> GetAllGroupSubjects();
        IQueryable<Subject> GetSubjectsInGroup(Guid? groupId);
        void AddAndSaveGroupsWithSubjects(List<GroupSubject> groupSubjects);
        void EditSubjectsInGroup(List<GroupSubject> choosenSubjects, List<GroupSubject> hadSubjects);
    }
}
