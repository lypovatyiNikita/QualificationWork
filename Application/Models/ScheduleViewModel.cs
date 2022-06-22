using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Models
{
    public class ScheduleViewModel
    {
        [BindProperty, DataType(DataType.Date)]
        public DateTime CurrentDateTime { get; set; }

        public Schedule[] CurrentSchedules { get; set; }

        public SelectList AllSheduleBlocks { get; set; }

        public string DateInString { get; set; }

        public bool isInGroup { get; set; }
    }
}
