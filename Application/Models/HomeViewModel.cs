using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class HomeViewModel
    {
        public IQueryable<NewsBlock> NewsBlocks { get; set; }
        public ScheduleViewModel ScheduleViewModel { get; set; }
    }
}
