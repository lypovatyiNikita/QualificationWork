using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class Teacher
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Аккаунт вчителя")]
        public string? TeacherId { get; set; }
        public UniversityUser TeacherUser { get; set; }

        public List<TeacherSubject> TeacherSubjects { get; set; }

        public List<ScheduleBlock> ScheduleBlocks { get; set; }
    }
}
