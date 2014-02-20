using System;

namespace TestTask.Core.Services
{
	public interface IEntityService
	{
		bool IsAdded{get;set;}
		bool IsEdited { get; set; }
		string Name{ get; set;}
	}
}

