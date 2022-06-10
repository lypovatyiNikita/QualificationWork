using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Areas.Methodist.Model
{
    public class ScheduleBlockModel
    {
        public ScheduleBlock BlockRef { get; set; }
        public SelectList TeachersRef { get; set; }
        public SelectList GroupsRef { get; set; }
    }
}
