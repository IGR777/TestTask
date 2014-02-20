using System;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using TestTask.Plugins.CoolPicture;

namespace TestTask.Plugins.CoolPicture.Droid
{
	public class Plugin
		: IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<ICoolPicture>(new DroidCoolPictureProvider());
		}
	}
}

