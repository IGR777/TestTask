using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace TestTask.Plugins.Pictures.Touch
{
	public class Plugin
		: IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IPictures>(new TouchPicturesProvider());
		}
	}
}

