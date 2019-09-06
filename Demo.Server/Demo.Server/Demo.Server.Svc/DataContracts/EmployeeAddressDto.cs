using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Svc.DataContracts
{
	public class EmployeeAddressDto
	{
		public int Oid { get; set; }
		public long EmpId { get; set; }
		public int AddId { get; set; }
	}
}
