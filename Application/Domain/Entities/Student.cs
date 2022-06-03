using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class Student
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Аккаунт студента")]
        public string? StudentId { get; set; }
        public UniversityUser StudentUser { get; set; }

        [Display(Name ="Група")]
        public Guid? GroupId { get; set; }
        public Group Group { get; set; }

        public List<StudentsEstimates> StudentsEstimates { get; set; }
    }
}
