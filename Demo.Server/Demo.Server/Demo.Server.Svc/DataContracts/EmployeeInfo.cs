using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Svc.DataContracts
{
	public class EmployeeInfoDto
	{
		public string EmployeeName { get; set; }

		public string EmployeeSurname { get; set; }

		public string DepartmentName { get; set; }

		public string FullAddress { get; set; }

		public string TownName { get; set; }

		public string CityName { get; set; }
	}
}
