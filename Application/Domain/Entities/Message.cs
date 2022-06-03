using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class Message
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Від кого")]
        public string UserName { get; set; }

        [Display(Name = "Кому")]
        public string NameId { get; set; }

        [Display(Name = "Повідомлення")]
        public string MessageText { get; set; }
    }
}
