using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface ISubjectRepository
    {
        IQueryable<Subject> GetAllSubjects();
        Subject GetSubjectById(Guid? id);
    }
}
