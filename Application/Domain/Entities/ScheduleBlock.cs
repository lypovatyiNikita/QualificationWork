using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
	public class ScheduleBlock : EntityBase
	{
		[Display(Name = "Викладач")]
		public Guid? TeacherId { get; set; }
		public Teacher Teacher { get; set; }

		[Display(Name = "Аудиторія")]
		public string Audience { get; set; }

		[Display(Name = "Група та курс")]
		public Guid? GroupId { get; set;}
		public Group Group { get; set; }

		public List<Schedule> Schedules { get; set; }
	}
}
