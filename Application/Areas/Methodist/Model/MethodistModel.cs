using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Areas.Methodist.Models
{
    public class MethodistModel
    {
        public SelectList Teachers { get; set; }
        public SelectList Students { get; set; }
        public SelectList StudentGroups { get; set; }
        public SelectList Subjects { get; set; }
    }
}
