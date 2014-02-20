using System;
using System.Threading.Tasks;

namespace TestTask.Plugins.Pictures
{
	public interface IPictures
	{
		bool SaveToDevice(string url);
	}
}

