using System;
using System.Collections.Generic;
using TestTask.Core.Models;

namespace TestTask.Core.Services
{
	public interface IDataService
	{
		void Insert(Entity entity);
		void Update(Entity entity);
		List<Entity> GetItems ();
	}
}

