using Application.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Areas.Methodist.Model
{
    public class TeacherModel
    {
        public Domain.Entities.Teacher Teacher { get; set; }
        public UniversityUser UniversityUser { get; set; }
        public List<string> Subjects { get; set; }
        public MultiSelectList SubjectsSelect { get; set; }
    }
}
