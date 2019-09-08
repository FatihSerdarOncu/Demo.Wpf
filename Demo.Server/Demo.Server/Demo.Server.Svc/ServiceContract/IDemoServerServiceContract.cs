using Demo.Server.Svc.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Svc
{
	[ServiceContract]
	public interface IDemoServerServiceContract
	{
		#region Address
		[OperationContract]
		List<AddressDto> GetAddress();

		[OperationContract]
		void InsertAddress(AddressDto addressObject);

		[OperationContract]
		bool UpdateAddress(AddressDto addressObject);

		[OperationContract]
		bool DeleteAddress(int addressId);
		#endregion

		#region City
		[OperationContract]
		List<CityDto> GetCity();

		[OperationContract]
		void InsertCity(CityDto cityObject);

		[OperationContract]
		bool UpdateCity(CityDto cityObject);

		[OperationContract]
		bool DeleteCity(int cityId);
		#endregion

		#region Department
		[OperationContract]
		List<DepartmentDto> GetDepartment();

		[OperationContract]
		void InsertDepartment(DepartmentDto depObject);

		[OperationContract]
		bool UpdateDepartment(DepartmentDto depObject);

		[OperationContract]
		bool DeleteDepartment(int depId);
		#endregion

		#region Employee
		[OperationContract]
		List<EmployeeInfoDto> GetEmployeeFullInfo();

		[OperationContract]
		List<EmployeeDto> GetEmployee();

		[OperationContract]
		void InsertEmployee(EmployeeDto employeeObject);

		[OperationContract]
		bool UpdateEmployee(EmployeeDto employeeObject);

		[OperationContract]
		bool DeleteEmployee(long EmployeeTc);
		#endregion

		#region EmployeeAddress
		[OperationContract]
		List<EmployeeAddressDto> GetEmployeeAddress();

		[OperationContract]
		void InsertEmployeeAddress(EmployeeAddressDto employeeAddressObject);

		[OperationContract]
		bool DeleteEmployeeAddress(int oid);
		#endregion

		#region Town
		[OperationContract]
		List<TownDto> GetTown();

		[OperationContract]
		void InsertTown(TownDto townObject);

		[OperationContract]
		bool UpdateTown(TownDto TownObject);

		[OperationContract]
		bool DeleteTown(int TownId);
		#endregion
	}
}
