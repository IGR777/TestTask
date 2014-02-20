using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using TestTask.Core.ViewModels;

namespace TestTask.UI.Droid
{
	[Activity(Label = "Test task")]
	public class GrandView : MvxTabActivity
	{
		protected GrandViewModel GrandViewModel
		{
			get { return base.ViewModel as GrandViewModel; }
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.GrandView);

			TabHost.TabSpec spec = TabHost.NewTabSpec("0");
			spec.SetIndicator("Contacts");
			spec.SetContent(this.CreateIntentFor(GrandViewModel.Contacts));
			TabHost.AddTab(spec);

			spec = TabHost.NewTabSpec("1");
			spec.SetIndicator("Pictures");
			spec.SetContent(this.CreateIntentFor(GrandViewModel.Pictures));
			TabHost.AddTab(spec);

			spec = TabHost.NewTabSpec("2");
			spec.SetIndicator ("Entities");
			spec.SetContent(this.CreateIntentFor(GrandViewModel.Entities));
			TabHost.AddTab(spec);

			spec = TabHost.NewTabSpec("3");
			spec.SetIndicator ("Cool Picture");
			spec.SetContent(this.CreateIntentFor(GrandViewModel.CoolPicture));
			TabHost.AddTab(spec);

			if (!string.IsNullOrEmpty (GrandViewModel.CurrentTab)) {
				TabHost.SetCurrentTabByTag (GrandViewModel.CurrentTab);
			}
		}
	}
}

