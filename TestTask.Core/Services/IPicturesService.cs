using System;

namespace TestTask.Core.Services
{
	public interface IPicturesService
	{
		bool IsRemoving{ get; set;}
		int RemovingId{ get; set;}
		bool IsAdded{get; set;}
		string CachedString{ get; set;}
	}
}

