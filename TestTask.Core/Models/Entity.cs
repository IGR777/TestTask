using System;
using System.Text;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace TestTask.Core.Models
{
	public class Entity
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public DateTime Updated { get; set; }

		public override string ToString ()
		{
			return Name;
		}
	}
}

