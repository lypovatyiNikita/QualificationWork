using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface ITeacherSubjectRepository
    {
        IQueryable<TeacherSubject> GetAllTeacherSubjects();
        IQueryable<Subject> GetSubjectsInTeacher(Guid teacherId);
        TeacherSubject GetTeacherSubjectById(Guid id);
        void AddAndSaveTeacherSubject(TeacherSubject newTeacherSubject);
        void AddAndSaveTeacherSubjects(List<TeacherSubject> newTeacherSubjects);
        void DeleteTeacherSubject(Guid id);
    }
}
