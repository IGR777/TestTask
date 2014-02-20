using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.CrossCore.Platform;
using TestTask.Core.ViewModels;
using Android.Graphics;

namespace TestTask.UI.Droid
{

	[Activity(Label = "Pictures")]
	public class PicturesView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.PicturesView);
		}
	}
}

