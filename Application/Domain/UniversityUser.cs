using Application.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Identity
{
    public class UniversityUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public List<Student> Students { get; set; }

        public List<Teacher> Teachers { get; set; }

		public override string ToString()
		{
            return Name + " " + Surname;
		}
	}
}
