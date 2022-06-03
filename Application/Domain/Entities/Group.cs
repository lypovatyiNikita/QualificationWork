using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class Group
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Display(Name="Назва групи")]
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public List<GroupSubject> GroupSubjects { get; set; }

        public List<ScheduleBlock> ScheduleBlocks { get; set; }
    }
}
