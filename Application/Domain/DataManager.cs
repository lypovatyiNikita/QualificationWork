using Application.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain
{
    public class DataManager
    {
        public INewsRepository NewsRepositoryRef;
        public IScheduleRepository ScheduleRepositoryRef;
        public IMessageRepository MessageRepositoryRef;
        public IScheduleBlockRepository ScheduleBlockRepositoryRef;
        public IStudentRepository StudentRepositoryRef;
        public IStudentsEstimatesRepository StudentsEstimatesRepositoryRef;
        public ITeacherRepository TeacherRepositoryRef;
        public ITeacherSubjectRepository TeacherSubjectRepositoryRef;
        public ISubjectRepository SubjectRepositoryRef;
        public IUniversityUserRepository UniversityUserRepositoryRef;
        public IGroupRepository GroupRepositoryRef;
        public IGroupSubjectRepository GroupSubjectRepositoryRef;

        public DataManager(INewsRepository newsRepository, IScheduleRepository scheduleRepository, IMessageRepository messageRepository, IScheduleBlockRepository scheduleBlockRepository, IStudentRepository studentRepository, IStudentsEstimatesRepository studentsEstimatesRepository, ITeacherRepository teacherRepository, ITeacherSubjectRepository teacherSubjectRepository, ISubjectRepository subjectRepository, IUniversityUserRepository universityUserRepository, IGroupRepository groupRepository, IGroupSubjectRepository groupSubjectRepository)
		{
            NewsRepositoryRef = newsRepository;
            ScheduleRepositoryRef = scheduleRepository;
            MessageRepositoryRef = messageRepository;
            ScheduleBlockRepositoryRef = scheduleBlockRepository;
            StudentRepositoryRef = studentRepository;
            StudentsEstimatesRepositoryRef = studentsEstimatesRepository;
            TeacherRepositoryRef = teacherRepository;
            TeacherSubjectRepositoryRef = teacherSubjectRepository;
            SubjectRepositoryRef = subjectRepository;
            UniversityUserRepositoryRef = universityUserRepository;
            GroupRepositoryRef = groupRepository;
            GroupSubjectRepositoryRef = groupSubjectRepository;
        }
    }
}
