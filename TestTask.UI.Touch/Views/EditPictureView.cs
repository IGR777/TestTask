using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace TestTask.UI.Touch
{
	public partial class EditPictureView : MvxViewController
	{

		private MvxImageViewLoader _imageHelper;

		public EditPictureView () : base ("EditPictureView", null)
		{
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


		public EditPictureViewModel EditPictureViewModel
		{
			get
			{
				return base.ViewModel as EditPictureViewModel;
			}
		}

		public string ImageUrl
		{
			get { return _imageHelper.ImageUrl; }
			set { 
				_imageHelper.ImageUrl = value; 
			}
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.


			var _rightButton = new UIBarButtonItem (UIBarButtonSystemItem.Add);
			_rightButton.Clicked += (object sender, EventArgs e) => EditPictureViewModel.SaveCommand.Execute (null);
			NavigationItem.RightBarButtonItem = _rightButton;
			NavigationItem.Title = "Edit picture";

			_imageHelper = new MvxImageViewLoader (() => kittenImageView);
			this.CreateBinding().For((view) => view.ImageUrl).To<EditPictureViewModel>(model => model.ImageUrl).Apply();
			this.CreateBinding(removeButton).To<EditPictureViewModel>(model => model.RemoveCommand).Apply();
		}
	}
}

