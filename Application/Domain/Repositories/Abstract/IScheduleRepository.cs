using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface IScheduleRepository
    {
        IQueryable<Schedule> GetAllSchedules();
        IQueryable<Schedule> GetAllSheduleByDate(DateTime needDateTime);
        IQueryable<Schedule> GetAllSheduleByDateInGroup(DateTime needDateTime, Guid? groupId);
        Schedule GetScheduleById(Guid ID);
        Schedule GetScheduleByParams(Schedule schedule);
        void AddAndSaveBlock(Schedule newSchedule);
        void DeleteBlock(Guid id);
    }
}
