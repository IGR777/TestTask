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
using Android.Views;
using TestTask.UI.Droid.Controls;

namespace TestTask.UI.Droid
{
	[Activity(Label = "Show picture")]
	public class ShowPictureView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ShowPictureView);


		}				
	}
}

