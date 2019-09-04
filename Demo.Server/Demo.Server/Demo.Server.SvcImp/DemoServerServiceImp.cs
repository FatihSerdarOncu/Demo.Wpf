using Demo.Server.Data;
using Demo.Server.Data.Model;
using Demo.Server.Svc;
using Demo.Server.Svc.DataContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.SvcImp
{
    public class DemoServerServiceImp : IDemoServerServiceContract
	{
		protected static DemoDataAdapter da = null;
		public DemoServerServiceImp()
		{
			if (da == null && ConfigurationManager.ConnectionStrings["EmployeeServer"] != null && !string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["EmployeeServer"].ConnectionString))
			{
				da = new DemoDataAdapter(ConfigurationManager.ConnectionStrings["EmployeeServer"].ConnectionString);
			}

		}

		#region City
		public List<CityDto> GetCity()
		{
			try
			{
				var tempCity = da.List<City>(null);
				
				return City.GetEntityCollection(tempCity);
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public void InsertCity(CityDto cityObject)
		{
			try
			{
				da.Insert<City>(new City() { CityId = cityObject.CityId,CityName = cityObject.CityName});
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool UpdateCity(CityDto cityObject)
		{
			try
			{
				if (da.Update<City>(new City() { CityId = cityObject.CityId, CityName = cityObject.CityName }) == 1)
					return true;
			}
			catch (Exception ex)
			{

				throw;
			}
			return false;
		}

		public bool DeleteCity(int cityId)
		{
			try
			{
				if (da.Delete<City>(cityId) == 1)
					return true;
			}
			catch (Exception ex)
			{
				throw;
			}
			return false;
		}

		#endregion

		#region Address
		public List<AddressDto> GetAddress()
		{
			try
			{
				var tempAddress = da.List<Address>(null);
				return Address.GetEntityCollection(tempAddress);
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public void InsertAddress(AddressDto addressObject)
		{
			try
			{
				da.Insert<Address>(new Address() {
					AddressId = addressObject.AddressId,
					FullAddress = addressObject.FullAddress,
					Town =  addressObject.Town
				});
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool UpdateAddress(AddressDto addressObject)
		{
			try
			{
				if (da.Update<Address>(new Address()
				{
					AddressId = addressObject.AddressId,
					FullAddress = addressObject.FullAddress,
					Town = addressObject.Town
				}) == 1)
					return true;
			}
			catch (Exception ex)
			{

				throw;
			}
			return false;
		}

		public bool DeleteAddress(int addressId)
		{
			try
			{
				if (da.Delete<Address>(addressId) == 1)
					return true;
			}
			catch (Exception ex)
			{
				throw;
			}
			return false;
		}
		#endregion

		#region Department
		public List<DepartmentDto> GetDepartment()
		{
			try
			{
				var tempDepartment = da.List<Department>(null);
				return Department.GetEntityCollection(tempDepartment);
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public void InsertDepartment(DepartmentDto depObject)
		{
			try
			{
				da.Insert<Department>(new Department() {
					DepartmentId = depObject.DepartmentId,
					DepartmentManager = depObject.DepartmentManager,
					DepartmentName = depObject.DepartmentName
				});
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool UpdateDepartment(DepartmentDto depObject)
		{
			try
			{
				if (da.Update<Department>(new Department()
				{
					DepartmentId = depObject.DepartmentId,
					DepartmentManager = depObject.DepartmentManager,
					DepartmentName = depObject.DepartmentName
				}) == 1)
					return true;
			}
			catch (Exception ex)
			{

				throw;
			}
			return false;
		}

		public bool DeleteDepartment(int depId)
		{
			try
			{
				if (da.Delete<Department>(depId) == 1)
					return true;
			}
			catch (Exception ex)
			{
				throw;
			}
			return false;
		}
		#endregion

		#region Employee
		public List<EmployeeDto> GetEmployee()
		{
			try
			{
				var tempEmployee = da.List<Employee>(null);
				return Employee.GetEntityCollection(tempEmployee);
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public void InsertEmployee(EmployeeDto employeeObject)
		{
			try
			{
				da.Insert<Employee>(new Employee() {
						EmployeeTCKN = employeeObject.EmployeeTCKN,
						EmployeeName = employeeObject.EmployeeName,
						EmployeeSurname = employeeObject.EmployeeSurname,
						Department = employeeObject.Department
				});
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool UpdateEmployee(EmployeeDto employeeObject)
		{
			try
			{
				if (da.Update<Employee>(new Employee()
				{
					EmployeeTCKN = employeeObject.EmployeeTCKN,
					EmployeeName = employeeObject.EmployeeName,
					EmployeeSurname = employeeObject.EmployeeSurname,
					Department = employeeObject.Department
				}) == 1)
					return true;
			}
			catch (Exception ex)
			{

				throw;
			}
			return false;
		}

		public bool DeleteEmployee(int EmployeeTc)
		{
			try
			{
				if (da.Delete<Employee>(EmployeeTc) == 1)
					return true;
			}
			catch (Exception ex)
			{
				throw;
			}
			return false;
		}
		#endregion

		#region Town
		public List<TownDto> GetTown()
		{
			try
			{
				var townList = da.List<Town>(null);
				return Town.GetEntityCollection(townList);
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public void InsertTown(TownDto townObject)
		{
			try
			{
				da.Insert<Town>(new Town() {
					TownId = townObject.TownId,
					TownName = townObject.TownName,
					City = townObject.City
				});
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool UpdateTown(TownDto townObject)
		{
			try
			{
				if (da.Update<Town>(new Town()
				{
					TownId = townObject.TownId,
					TownName = townObject.TownName,
					City = townObject.City
				}) == 1)
					return true;
			}
			catch (Exception ex)
			{

				throw;
			}
			return false;
		}

		public bool DeleteTown(int TownId)
		{
			try
			{
				if (da.Delete<Town>(TownId) == 1)
					return true;
			}
			catch (Exception ex)
			{
				throw;
			}
			return false;
		}
		#endregion
	}
}
