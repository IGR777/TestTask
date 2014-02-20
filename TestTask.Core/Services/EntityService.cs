using System;

namespace TestTask.Core.Services
{
	public class EntityService : IEntityService
	{
		private bool _isEdited;
		public bool IsEdited
		{ 
			get {return _isEdited;} 
			set	{_isEdited = value;} 
		}
			
		private bool _isAdded;
		public bool IsAdded
		{ 
			get {return _isAdded;} 
			set	{_isAdded = value;} 
		}

		private string _name;
		public string Name
		{ 
			get {return _name;} 
			set	{_name = value;} 
		}
	}
}

