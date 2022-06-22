using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Areas.Methodist.Model
{
    public class StudentModel
    {
        public Domain.Entities.Student Student { get; set; }
        public UniversityUser UniversityUser { get; set; }
        public SelectList Groups { get; set; }
    }
}
