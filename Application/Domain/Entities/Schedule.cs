using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class Schedule
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Блок розкладу")]
        public Guid? BlockId { get; set; }
        public ScheduleBlock Block { get; set; }

        [Display(Name = "Номер пари")]
        public int Couple { get; set; }

        [Display(Name = "Дата проведення")]
        [DataType(DataType.Date)]
        public DateTime DateOfBlock { get; set; }
    }
}
