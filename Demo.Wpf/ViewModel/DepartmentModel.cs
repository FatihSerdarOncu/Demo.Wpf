using Demo.Helpers;
using Demo.Server.Svc.DataContracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Wpf.ViewModel
{
    class DepartmentModel
    {
		public class Departman
		{
			public string DepartmentName { get; set; }
			public string DepartmentManager { get; set; }
			
		}
		public ObservableCollection<Departman> DepartmentList()
		{
			ObservableCollection<Departman> genericList = new ObservableCollection<Departman>();

			var department = ServiceAdapter.Instance.GetDepartmentList();

			foreach (DepartmentDto emp in department)
			{
				genericList.Add(new Departman()
				{
					DepartmentName = emp.DepartmentName,
					DepartmentManager = emp.DepartmentManager
				});
			}

			return genericList;
		}
	}
}
