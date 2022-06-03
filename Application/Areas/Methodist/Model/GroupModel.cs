using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Areas.Methodist.Model
{
    public class GroupModel
    {
        public Group Group { get; set; }
        public SelectList Groups { get; set; }
        public List<string> SubjectsId { get; set; }
        public SelectList Subjects { get; set; }
    }
}
