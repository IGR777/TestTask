using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.ViewModels;

namespace TestTask.UI.Touch
{
	public partial class EntityEditView : MvxViewController
	{
		public EntityEditView () : base ("EntityEditView", null)
		{
		}

		public EntityEditViewModel EntityEditViewModel
		{
			get
			{
				return base.ViewModel as EntityEditViewModel;
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			// show the nav bar when this controller appears
			this.NavigationController.SetNavigationBarHidden (false, true);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			// hide the nav bar when other controllers appear
			this.NavigationController.SetNavigationBarHidden (true, true);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			var _rightButton = new UIBarButtonItem ("",UIBarButtonItemStyle.Done, null);
			_rightButton.Clicked += (object sender, EventArgs e) => EntityEditViewModel.Proceed.Execute (null);
			NavigationItem.RightBarButtonItem = _rightButton;

			this.CreateBinding (Name).To<EntityEditViewModel> (vm=>vm.Name).Apply();
			this.CreateBinding (Description).To<EntityEditViewModel> (vm=>vm.Description).Apply();
			this.CreateBinding (IsActive).To<EntityEditViewModel> (vm=>vm.IsActive).Apply();
			this.CreateBinding (_rightButton).For(rb=>rb.Title).To<EntityEditViewModel> (vm=>vm.ButtonText).Apply();
			this.CreateBinding (nameValidation).To<EntityEditViewModel> (vm => vm.Errors["Name"]).Apply();

			this.Name.ShouldReturn += HelperMethods.ReasignTextFieldResponder;
			this.Description.ShouldReturn += HelperMethods.ReasignTextFieldResponder;
		}
	}
}

