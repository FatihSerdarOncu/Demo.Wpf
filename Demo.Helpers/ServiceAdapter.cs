using Demo.Server.Svc;
using Demo.Server.Svc.DataContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Helpers
{
	public class ServiceAdapter
	{
		#region singleton

		private static ServiceAdapter instance = null;
		private static readonly object padlock = new object();

		string DemoServerSvcUrl = null;

		ServiceAdapter()
		{
			DemoServerSvcUrl = ConfigurationManager.AppSettings["DemoServerSvcUrl"];

		}

		public static ServiceAdapter Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new ServiceAdapter();
					}
					return instance;
				}
			}
		}

		#endregion

		private void InvokeService<T>(Action<T> work, bool throwIfError = true)
		{
			ChannelFactory<T> cf = null;
			try
			{
				cf = WCFHandler<T>.ChannelFactory(DemoServerSvcUrl);


				if (cf.State != CommunicationState.Opened)
					cf.Open();
				T chn = cf.CreateChannel();

				work(chn);
				(chn as IClientChannel).Close();
				cf.Close();
			}
			catch (Exception e)
			{
				cf.Abort();
				if (throwIfError)
					throw;
			}
		}

        #region Address Service

        public List<AddressDto> GetAddressList()
        {
            List<AddressDto> res = null;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                res = c.GetAddress();
            });
            return res;
        }

        public void InsertAddress(AddressDto addObject)
        {
            
            InvokeService<IDemoServerServiceContract>(c =>
            {
                 c.InsertAddress(addObject);
            });
        }

        public bool UpdateAddress(AddressDto addObject)
        {
            bool res = false;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.UpdateAddress(addObject);
            });
            return res;
        }

        public bool DeleteAddress(int addressId)
        {
            bool res = false;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.DeleteAddress(addressId);
            });
            return res;
        }

        #endregion

        #region City Service
        public List<CityDto> GetCityList()
        {
            List<CityDto> res = null;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                res = c.GetCity();
            });
            return res;
        }

        public void Insertcity(CityDto cityObject)
        {

            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.InsertCity(cityObject);
            });
        }

        public bool UpdateCity(CityDto cityObject)
        {
            bool res = false;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.UpdateCity(cityObject);
            });
            return res;
        }

        public bool DeleteCity(int cityId)
        {
            bool res = false;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.DeleteCity(cityId);
            });
            return res;
        }


        #endregion

        #region Department

        public List<DepartmentDto> GetDepartmentList()
        {
            List<DepartmentDto> res = null;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                res = c.GetDepartment();
            });
            return res;
        }

        public void InsertDepartment(DepartmentDto depObject)
        {

            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.InsertDepartment(depObject);
            });
        }

        public bool UpdateDepartment(DepartmentDto depObject)
        {
            bool res = false;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.UpdateDepartment(depObject);
            });
            return res;
        }

        public bool DeleteDepartment(int depId)
        {
            bool res = false;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.DeleteDepartment(depId);
            });
            return res;
        }
        #endregion

        #region Employee

        public List<EmployeeDto> GetEmployeeList()
        {
            List<EmployeeDto> res = null;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                res = c.GetEmployee();
            });
            return res;
        }

        public void InsertEmployee(EmployeeDto empObject)
        {

            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.InsertEmployee(empObject);
            });
        }

        public bool UpdateEmployee(EmployeeDto empObject)
        {
            bool res = false;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.UpdateEmployee(empObject);
            });
            return res;
        }

        public bool DeleteEmployee(int empTC)
        {
            bool res = false;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.DeleteEmployee(empTC);
            });
            return res;
        }
        #endregion

        #region Town

        public List<TownDto> GetTownList()
        {
            List<TownDto> res = null;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                res = c.GetTown();
            });
            return res;
        }

        public void InsertTown(TownDto townObject)
        {

            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.InsertTown(townObject);
            });
        }

        public bool UpdateTown(TownDto townObject)
        {
            bool res = false;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.UpdateTown(townObject);
            });
            return res;
        }

        public bool DeleteTown(int townId)
        {
            bool res = false;
            InvokeService<IDemoServerServiceContract>(c =>
            {
                c.DeleteTown(townId);
            });
            return res;
        }
        #endregion

    }
}
