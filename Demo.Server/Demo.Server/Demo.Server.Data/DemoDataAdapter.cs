using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server.Data
{
	public class DemoDataAdapter
	{
		string connectionString;
		string sqlCommandGeneral;
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


		public List<string> EmployeInformation()
		{
			List<string> returnValue = new List<string>();

			//
			// The program accesses the connection string.
			// ... It uses it on a connection.
			//
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				//
				// SqlCommand should be created inside using.
				// ... It receives the SQL statement.
				// ... It receives the connection object.
				// ... The SQL text works with a specific database.
				//

				sqlCommandGeneral = String.Format(
					"SELECT emp.EmployeeName,emp.EmployeeSurname,dep.DepartmentName, adr.FullAddress,t.TownName,c.CityName" +
					" FROM Employee as emp " +
					" INNER JOIN Department as dep ON emp.Department = dep.DepartmentId" +
					" INNER JOIN EmployeeAddress as empAdr ON emp.EmployeeTCKN = empAdr.EmpId" +
					" INNER JOIN Address as adr ON empAdr.AddId = adr.AddressId" +
					" INNER JOIN Town as t ON adr.Town = t.TownId" +
					" INNER JOIN City as c ON t.City = c.CityId"
					);
				using (SqlCommand command = new SqlCommand(sqlCommandGeneral, connection))
				{
					//
					// Instance methods can be used on the SqlCommand.
					// ... These read data.
					//
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							StringBuilder sb = new StringBuilder();
							for (int i = 0; i < reader.FieldCount; i++)
							{
								sb.Append(reader.GetValue(i).ToString() + "-");
								Console.WriteLine(reader.GetValue(i));
							}
							returnValue.Add(sb.ToString());

							Console.WriteLine();
						}
					}
				}
			}
			List<string> temp = new List<string>(returnValue[0].Split('-'));
			return returnValue;
		}

	}
}
