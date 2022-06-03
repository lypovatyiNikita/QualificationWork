using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class Subject
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Назва")]
        public string Name { get; set; }

        public List<TeacherSubject> TeachersInSubject { get; set; }

        public List<GroupSubject> GroupsWithSubject { get; set; }

        public List<StudentsEstimates> SubjectStudentsEstimates { get; set; }
    }
}
