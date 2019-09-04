using Demo.Server.Svc.DataContracts;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Data.Model
{
	[PrimaryKey("DepartmentId")]
	[TableName("Department")]
	public class Department
	{
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
		public string DepartmentManager { get; set; }

		public static List<DepartmentDto> GetEntityCollection(List<Department> departmentList)
		{
			var result = from s in departmentList select GetEntity(s);
			return result.ToList();
		}

		internal static DepartmentDto GetEntity(Department dep)
		{
			if (dep == null)
				throw new ArgumentNullException("department", "Mapping departmentDto TO department");

			var depDto = new DepartmentDto();
			depDto.DepartmentId= dep.DepartmentId;
			depDto.DepartmentManager= dep.DepartmentManager;
			depDto.DepartmentName= dep.DepartmentName;
			return depDto;
		}
	}
}
