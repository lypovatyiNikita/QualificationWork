using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface IStudentsEstimatesRepository
    {
        IQueryable<StudentsEstimates> GetAllEstimatesInStudent(Guid studentId);
        List<StudentsEstimates> GetAllEstimatesWithSubjects(List<Subject> subjects);
        void AddOrEdirEstimates(List<StudentsEstimates> studentsEstimates);
        void EditSubjectsInStudent(List<StudentsEstimates> choosenSubjects, List<StudentsEstimates> hadSubjects);
    }
}
