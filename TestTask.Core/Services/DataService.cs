using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using TestTask.Core.Models;

namespace TestTask.Core.Services
{
	public class DataService : IDataService
	{
		private readonly ISQLiteConnection _connection;

		public DataService(ISQLiteConnectionFactory factory)
		{
			_connection = factory.Create("myDB.sql");
			_connection.CreateTable<Entity>();
		}
			

		public void Insert(Entity entity)
		{
			_connection.Insert(entity);
		}
			

		public void Update(Entity entity)
		{
			_connection.Update(entity);
		}

		public List<Entity> GetItems()
		{
			return _connection.Table<Entity> ()
					.ToList ();
		}
			
	}
}

