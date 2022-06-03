using Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Areas.Teacher.Model
{
    public class StatementModel
    {
        public IQueryable<Subject> Subjects { get; set; }

        public IQueryable<StudentsEstimates> StudentsEstimates { get; set; }
    }
}
