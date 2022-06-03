using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface IStudentRepository
    {
        IQueryable<Student> GetAllStudents();
        Student GetStudentById(Guid? id);
        Student GetStudentByUserId(string userId);
        void AddAndSaveStudent(Student newSchedule);
        void DeleteStudent(Guid id);
    }
}
