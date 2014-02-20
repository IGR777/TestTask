using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace TestTask.Plugins.Pictures.Droid
{
	public class Plugin
		: IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IPictures>(new DroidPicturesProvider());
		}
	}
}

