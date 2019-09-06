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
			//da.Insert<Employee>(new Employee() {EmployeeTCKN =  41485835882,EmployeeName = "Sunucudan",EmployeeSurname="Denedim",Department=1});

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
