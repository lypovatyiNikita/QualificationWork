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
        Schedule GetScheduleById(Guid ID);
        void AddAndSaveBlock(Schedule newSchedule);
        void DeleteBlock(Guid id);
    }
}
