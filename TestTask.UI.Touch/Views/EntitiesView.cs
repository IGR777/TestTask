using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.ViewModels;
using TestTask.Core.Models;
using TestTask.UI.Touch.Models;

namespace TestTask.UI.Touch
{
	public partial class EntitiesView : MvxViewController
	{
		public EntitiesView () : base ("EntitiesView", null)
		{
		}

		public EntitiesViewModel EntitiesViewModel
		{
			get
			{
				return base.ViewModel as EntitiesViewModel;
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			var _rightButton = new UIBarButtonItem (UIBarButtonSystemItem.Add);
			_rightButton.Clicked += (object sender, EventArgs e) => EntitiesViewModel.AddCommand.Execute (null);
			NavigationItem.RightBarButtonItem = _rightButton;

			var source = new MvxEntityViewSource(TableView, "TitleText .");
			TableView.Source = source;

			var set = this.CreateBindingSet<EntitiesView, EntitiesViewModel>();
			set.Bind(source).To(vm => vm.Items);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.EditCommand);
			set.Apply();
		}
	}
}

