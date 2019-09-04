using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Data
{
	public class DemoDataAdapter
	{
		string connectionString;
		public DemoDataAdapter(string _connStr)
		{
			this.connectionString = _connStr;
		}

		public T SingleOrDefault<T>(Func<T, bool> filter)
		{
			using (NPoco.IDatabase dbContext = new NPoco.Database(connectionString, NPoco.DatabaseType.SqlServer2012))
			{
				return dbContext.Fetch<T>().Where(filter).SingleOrDefault();
			}
		}

		public List<T> List<T>(Func<T, bool> filter)
		{
			using (NPoco.IDatabase dbContext = new NPoco.Database(connectionString, NPoco.DatabaseType.SqlServer2012))
			{
				if (filter != null)
					return dbContext.Fetch<T>().Where(filter).ToList();
				else
					return dbContext.Fetch<T>().ToList();
			}
		}

		public void Insert<T>(T obj)
		{
			using (NPoco.IDatabase dbContext = new NPoco.Database(connectionString, NPoco.DatabaseType.SqlServer2012))
			{
				dbContext.Insert<T>(obj);
			}
		}

		public int Update<T>(T obj)
		{
			using (NPoco.IDatabase dbContext = new NPoco.Database(connectionString, NPoco.DatabaseType.SqlServer2012))
			{
				return dbContext.Update(obj);
			}
		}

		public int Delete<T>(int id)
		{
			using (NPoco.IDatabase dbContext = new NPoco.Database(connectionString, NPoco.DatabaseType.SqlServer2012))
			{
				var obj = dbContext.SingleById<T>(id);
				return dbContext.Delete<T>(obj);
			}
		}

	}
}
