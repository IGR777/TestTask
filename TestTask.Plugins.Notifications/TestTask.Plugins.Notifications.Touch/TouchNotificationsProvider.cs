using System;
using MonoTouch.UIKit;

namespace TestTask.Plugins.Notifications.Touch
{
	public class TouchNotificationsProvider : INotifications
	{
		public void DisplayNotification(string message)
		{
			var notificationView = new UIAlertView("", message, null, "OK", null);
			notificationView.Show();
		}
	}
}

