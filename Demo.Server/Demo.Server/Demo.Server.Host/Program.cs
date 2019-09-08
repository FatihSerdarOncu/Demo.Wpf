using Demo.Server.Data;
using Demo.Server.Data.Model;
using Demo.Server.Svc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Host
{
	class Program
	{
		
		static DemoService svc;
		static void Main(string[] args)
		{
			//DemoDataAdapter da = new DemoDataAdapter(ConfigurationManager.ConnectionStrings["EmployeeServer"].ConnectionString);
			//var d = da.Update<Employee>(new Employee() {EmployeeTCKN = 999999999999, EmployeeName = "Çok editlemelik",EmployeeSurname="kıh kıh",Department=2});

			try
			{
				if (!Environment.UserInteractive)
				{
					svc = new DemoService();
					ServiceBase.Run(svc);
					Console.ReadLine();
				}
				else
				{

					svc = new DemoService();
					svc.Start();
					Console.ReadLine();
				}

			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}
