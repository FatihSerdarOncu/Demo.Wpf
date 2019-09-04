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
        public class Personel
        {
            public int TCKN { get; set; }
            public string PersonelName { get; set; }
            public string PersonelSurname { get; set; }
            public string Department { get; set; }
            public string Address { get; set; }
        }
        public ObservableCollection<Personel> PersonelList()
        {
            ObservableCollection<Personel> genericList = new ObservableCollection<Personel>();

            var department = ServiceAdapter.Instance.GetDepartmentList();
            foreach(EmployeeDto  emp in  ServiceAdapter.Instance.GetEmployeeList()){
                genericList.Add(new Personel()
                {
                     TCKN = emp.EmployeeTCKN,
                     PersonelName = emp.EmployeeName,
                     PersonelSurname =  emp.EmployeeSurname,
                     Department = department.FirstOrDefault(x => x.DepartmentId == emp.Department).DepartmentName
                     

                });
            }

            return genericList;
        }
    }
}
