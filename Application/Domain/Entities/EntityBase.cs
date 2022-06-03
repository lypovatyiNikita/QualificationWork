using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class EntityBase
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }
    }
}
