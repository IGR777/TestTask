using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace TestTask.Plugins.CoolPicture.Touch
{
	public class Plugin
		: IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<ICoolPicture>(new TouchCoolPictureProvider());
		}
	}
}

