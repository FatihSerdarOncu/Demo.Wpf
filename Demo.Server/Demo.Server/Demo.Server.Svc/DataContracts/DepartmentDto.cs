using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Svc.DataContracts
{
	public class DepartmentDto
	{
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
		public string DepartmentManager { get; set; }
	}
}
