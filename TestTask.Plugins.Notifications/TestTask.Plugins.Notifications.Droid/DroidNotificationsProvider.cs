using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.Views;

using Cirrious.CrossCore.Droid.Platform;

namespace TestTask.Plugins.Notifications.Droid
{
	class DroidNotificationsProvider :INotifications
	{
		public void DisplayNotification(string message)
		{
			var globals = Mvx.Resolve<Cirrious.CrossCore.Droid.IMvxAndroidGlobals>();
			var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity as IMvxBindingContextOwner;
			// note that we're not using Binding in this Inflation - but the overhead is minimal - so use it anyway!
			View layoutView = activity.BindingInflate(Resource.Layout.ToastLayout, null);
			var text = layoutView.FindViewById<TextView>(Resource.Id.MessageText);
			text.Text = message;
			var toast = new Toast(globals.ApplicationContext);
			toast.SetGravity(GravityFlags.CenterVertical, 0, 0);
			toast.Duration = ToastLength.Long;
			toast.View = layoutView;
			toast.Show();

		}
	}
}

