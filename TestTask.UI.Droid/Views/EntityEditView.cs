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
using Cirrious.MvvmCross.Droid.Views;
using TestTask.Core.ViewModels;

namespace TestTask.UI.Droid
{
	[Activity (Label = "Entities")]			
	public class EntityEditView : MvxActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.EntityEditView);

			// Create your application here
		}
	}
}

