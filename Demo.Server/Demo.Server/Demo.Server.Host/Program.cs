using Demo.Server.Svc;
using System;
using System.Collections.Generic;
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
