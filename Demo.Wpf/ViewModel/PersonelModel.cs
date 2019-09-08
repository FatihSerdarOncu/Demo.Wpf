using Demo.Helpers;
using Demo.Server.Svc.DataContracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Wpf
{
    public class PersonelModel
    {
        public class Personnel
        {
            public long TCKN { get; set; }
            public string PersonelName { get; set; }
            public string PersonelSurname { get; set; }
            public string Department { get; set; }
            public string Address { get; set; }
            public string Town { get; set; }
            public string City { get; set; }
        }
        public ObservableCollection<Personnel> PersonelList()
        {
            ObservableCollection<Personnel> genericList = new ObservableCollection<Personnel>();

			var employee = ServiceAdapter.Instance.GetEmployeeFullInfo();

			foreach (EmployeeInfoDto emp in employee)
			{
				genericList.Add(new Personnel()
				{
					TCKN = emp.TCKN,
					PersonelName = emp.EmployeeName,
					PersonelSurname = emp.EmployeeSurname,
					Department = emp.DepartmentName,
					Address = emp.FullAddress,
					Town = emp.TownName,
					City = emp.CityName
				});
			}

			return genericList;
        }
    }
}
