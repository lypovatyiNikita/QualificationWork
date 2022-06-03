using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Areas.Student.Model
{
    public class StatementModel
    {
        public List<Subject> Subjects { get; set; }

        public List<StudentsEstimates> StudentsEstimates { get; set; }
    }
}
