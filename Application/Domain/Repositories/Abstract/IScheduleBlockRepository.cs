using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.Abstract
{
    public interface IScheduleBlockRepository
    {
        IQueryable<ScheduleBlock> GetAllBlocks();
        ScheduleBlock GetBlockById(Guid id);
        void AddAndSaveBlock(ScheduleBlock newBlock);
        void DeleteBlock(Guid id);
    }
}
