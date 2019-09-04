using Demo.Server.Svc;
using Demo.Server.SvcImp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Server.Host
{
	partial class DemoService : ServiceBase
	{
		private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
		private Thread _thread;
		ServiceHost svcHost;

		public DemoService()
		{
			this.CanStop = true;
			this.CanPauseAndContinue = true;
			this.AutoLog = true;
		}

		protected override void OnStart(string[] args)
		{
			base.OnStart(args);
			Start();
		}

		protected override void OnStop()
		{
			_shutdownEvent.Set();
			if (!_thread.Join(3000))
			{ // give the thread 3 seconds to stop
				_thread.Abort();
			}

			base.OnStop();
		}

		protected override void OnPause()
		{
			base.OnPause();
		}


		public void Start()
		{
			_thread = new Thread(WorkerThreadFunc);
			_thread.Name = "DemoServer";
			_thread.IsBackground = true;
			_thread.Start();

			try
			{
				StartServices();
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		private void StartServices()
		{
			string urlSvc = ConfigurationManager.AppSettings["DemoServerSvcUrl"];

			svcHost = WCFUtil.Run<DemoServerServiceImp, IDemoServerServiceContract>(urlSvc);

		}

		private void WorkerThreadFunc()
		{
			while (!_shutdownEvent.WaitOne(0))
			{
				Thread.Sleep(1000);
			}
		}
	}
}
