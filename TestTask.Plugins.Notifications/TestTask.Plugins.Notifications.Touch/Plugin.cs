using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace TestTask.Plugins.Notifications.Touch
{
	public class Plugin
		: IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<INotifications>(new TouchNotificationsProvider());
		}
	}
}

