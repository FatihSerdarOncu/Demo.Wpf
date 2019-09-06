using Demo.Server.Svc.DataContracts;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Data.Model
{
	[PrimaryKey("Oid")]
	[TableName("EmployeeAddress")]
	public class EmployeeAddress
	{
		public int Oid { get; set; }
		public long EmpId { get; set; }
		public int AddId { get; set; }

		public static List<EmployeeAddressDto> GetEntityCollection(List<EmployeeAddress> empAddressList)
		{
			var result = from s in empAddressList select GetEntity(s);
			return result.ToList();
		}

		internal static EmployeeAddressDto GetEntity(EmployeeAddress empAddress)
		{
			if (empAddress == null)
				throw new ArgumentNullException("EmployeeAddress", "Mapping EmployeeAddressDto TO EmployeeAddress");

			var empAddDto = new EmployeeAddressDto();
			empAddDto.Oid = empAddress.Oid;
			empAddDto.EmpId = empAddress.EmpId;
			empAddDto.AddId = empAddress.AddId;

			return empAddDto;
		}
	}
}
