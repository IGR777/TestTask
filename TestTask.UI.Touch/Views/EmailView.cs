using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.Models;
using TestTask.Core.ViewModels;

namespace TestTask.UI.Touch
{
	public partial class EmailView : MvxViewController
	{
		public EmailView () : base ("EmailView", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public EmailViewModel EmailViewModel
		{
			get
			{
				return base.ViewModel as EmailViewModel;
			}
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
			NavigationItem.Title = "Send Email";
			var _rightButton = new UIBarButtonItem (UIBarButtonSystemItem.Action);
			_rightButton.Clicked += (object sender, EventArgs e) => EmailViewModel.SendCommand.Execute (null);
			NavigationItem.RightBarButtonItem = _rightButton;
			EmailTextField.BorderStyle = UITextBorderStyle.RoundedRect;

			this.CreateBinding(To).To<EmailViewModel>(vm => vm.To).Apply();
			this.CreateBinding(Cc).To<EmailViewModel>(vm => vm.CC).Apply();
			this.CreateBinding(Subject).To<EmailViewModel>(vm => vm.Subject).Apply();
			this.CreateBinding(EmailTextField).To<EmailViewModel>(vm => vm.EmailText).Apply();

			this.To.ShouldReturn += HelperMethods.ReasignTextFieldResponder;
			this.Cc.ShouldReturn += HelperMethods.ReasignTextFieldResponder;
			this.Subject.ShouldReturn += HelperMethods.ReasignTextFieldResponder;
			this.EmailTextField.ShouldReturn += HelperMethods.ReasignTextFieldResponder;

		}
	}
}

