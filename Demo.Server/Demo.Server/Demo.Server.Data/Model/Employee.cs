using Demo.Server.Svc.DataContracts;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Data.Model
{
	[PrimaryKey("EmployeeTCKN", AutoIncrement = false)]
	[TableName("Employee")]
	public class Employee
	{
		public long EmployeeTCKN { get; set; }
		public string EmployeeName { get; set; }
		public string EmployeeSurname { get; set; }
		public int Department { get; set; }

		public static List<EmployeeDto> GetEntityCollection(List<Employee> empList)
		{
			var result = from s in empList select GetEntity(s);
			return result.ToList();
		}

		internal static EmployeeDto GetEntity(Employee emp)
		{
			if (emp == null)
				throw new ArgumentNullException("employee", "Mapping employeeDto TO employee");

			var empDto = new EmployeeDto();
			empDto.EmployeeTCKN = emp.EmployeeTCKN;
			empDto.EmployeeName = emp.EmployeeName;
			empDto.EmployeeSurname = emp.EmployeeSurname;
			empDto.Department = emp.Department;

			return empDto;
		}

	}
}
