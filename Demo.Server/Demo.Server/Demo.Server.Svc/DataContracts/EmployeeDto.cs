using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Svc.DataContracts
{
	public class EmployeeDto
	{
		public long EmployeeTCKN { get; set; }
		public string EmployeeName { get; set; }
		public string EmployeeSurname { get; set; }
		public int Department { get; set; }
	}
}
