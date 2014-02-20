using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace TestTask.Plugins.Contacts.Droid
{
	public class Plugin
		: IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IContacts>(new DroidContactsProvider());
		}
	}
}

