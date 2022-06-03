using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class GroupSubject
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        public Guid? GroupId { get; set; }
        public Group Group { get; set; }

        public Guid? SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
