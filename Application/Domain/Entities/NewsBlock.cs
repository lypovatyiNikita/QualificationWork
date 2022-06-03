using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.Domain.Entities
{
    public class NewsBlock: EntityBase
    {
        public NewsBlock() => CreateDate = DateTime.UtcNow;

        [Display(Name = "Короткий опис")]
        public string Subtitle { get; set; }

        [Display(Name = "Путь до картинки")]
        public string ImagePath { get; set; }

        [Display(Name = "Опис")]
        public string Text { get; set; }

        [Display(Name = "Дата створення")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
    }
}
