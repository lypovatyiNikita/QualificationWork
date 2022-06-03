using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class StudentsEstimates
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Display(Name ="Студент")]
        public Guid? StudentId { get; set; }
        public Student Student { get; set; }

        [Display(Name = "Предмет")]
        public Guid? SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Display(Name = "Оцінка")]
        public float Estimate { get; set; }
    }
}
