using Application.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Repositories.EntityFramework
{
	public class EFRoleRepository : IRoleRepository
	{
		public const string STUDENT_ROLE_ID = "839c91ae-d73d-4c2b-aa11-7602e2e0189a";
		public const string TEACHER_ROLE_ID = "ff3ba5ed-a69f-44da-886b-f1d54c2bc49c";
		public const string METHODIST_ROLE_ID = "eb782347-a46d-4874-aeac-ceafb3bc59d3";
	}
}
