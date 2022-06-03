using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface ITeacherRepository
    {
        IQueryable<Teacher> GetAllTeachers();
        Teacher GetTeacherByUserId(string userId);
        Teacher GetTeacherById(Guid id);
        void AddAndSaveTeacher(Teacher newTeacher);
        void DeleteTeacher(Guid id);
    }
}
