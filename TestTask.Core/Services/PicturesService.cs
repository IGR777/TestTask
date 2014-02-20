using System;

namespace TestTask.Core.Services
{
	public class PicturesService: IPicturesService
	{
		private bool _isRemoving;
		public bool IsRemoving
		{ 
			get {return _isRemoving;} 
			set	{_isRemoving = value;} 
		}

		private int _removingId;
		public int RemovingId
		{ 
			get {return _removingId;} 
			set	{_removingId = value;} 
		}
		private bool _isAdded;
		public bool IsAdded
		{ 
			get {return _isAdded;} 
			set	{_isAdded = value;} 
		}

		private string _cachedString;
		public string CachedString
		{ 
			get {return _cachedString;} 
			set	{_cachedString = value;} 
		}
	}
}

