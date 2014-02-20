using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;
using MonoTouch.CoreGraphics;


namespace TestTask.UI.Touch
{
	public partial class ShowPictureView : MvxViewController
	{
		private MvxImageViewLoader _imageHelper;
		public ShowPictureView () : base ("ShowPictureViewModel", null)
		{
		}
		UIRotationGestureRecognizer rotateGesture;
		UIPanGestureRecognizer panGesture;
		UIPinchGestureRecognizer pinchGesture;
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


		public ShowPictureViewModel ShowPictureViewModel
		{
			get
			{
				return base.ViewModel as ShowPictureViewModel;
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

			showKittenImageView.UserInteractionEnabled = true;

			float r = 0;
			float dx = 0;
			float dy = 0;

			var _rightButton = new UIBarButtonItem (UIBarButtonSystemItem.Edit);
			_rightButton.Clicked += (object sender, EventArgs e) => ShowPictureViewModel.EditCommand.Execute (null);
			NavigationItem.RightBarButtonItem = _rightButton;
			NavigationItem.Title = "Show picture";

			_imageHelper = new MvxImageViewLoader (() => showKittenImageView);
			this.CreateBinding().For((view) => view.ImageUrl).To<ShowPictureViewModel>(model => model.ImageUrl).Apply();

			rotateGesture = new UIRotationGestureRecognizer ((rg) => {
				if ((rg.State == UIGestureRecognizerState.Began || rg.State == UIGestureRecognizerState.Changed) && (rg.NumberOfTouches == 2)) {

					showKittenImageView.Transform = CGAffineTransform.MakeRotation (rg.Rotation + r);
				} else if (rg.State == UIGestureRecognizerState.Ended) {
					r += rg.Rotation;
				}
			});

			panGesture = new UIPanGestureRecognizer ((pg) => {
				if ((pg.State == UIGestureRecognizerState.Began || pg.State == UIGestureRecognizerState.Changed) && (pg.NumberOfTouches == 1)) {

					var p0 = pg.LocationInView (View);

					if (dx == 0)
						dx = p0.X - showKittenImageView.Center.X;

					if (dy == 0)
						dy = p0.Y - showKittenImageView.Center.Y;

					var p1 = new PointF (p0.X - dx, p0.Y - dy);

					showKittenImageView.Center = p1;
				} else if (pg.State == UIGestureRecognizerState.Ended) {
					dx = 0;
					dy = 0;
				}
			});

			pinchGesture = new UIPinchGestureRecognizer ((gestureRecognizer) => {
				if (gestureRecognizer.State == UIGestureRecognizerState.Began) {
					var image = gestureRecognizer.View;
					var locationInView = gestureRecognizer.LocationInView (image);
					var locationInSuperview = gestureRecognizer.LocationInView (image.Superview);

					image.Layer.AnchorPoint = new PointF (locationInView.X / image.Bounds.Size.Width, locationInView.Y / image.Bounds.Size.Height);
					image.Center = locationInSuperview;
				}
				if (gestureRecognizer.State == UIGestureRecognizerState.Began || gestureRecognizer.State == UIGestureRecognizerState.Changed) {
					gestureRecognizer.View.Transform *= CGAffineTransform.MakeScale (gestureRecognizer.Scale, gestureRecognizer.Scale);
					// Reset the gesture recognizer's scale - the next callback will get a delta from the current scale.
					gestureRecognizer.Scale = 1;
				}
			});
			showKittenImageView.AddGestureRecognizer (panGesture);
			showKittenImageView.AddGestureRecognizer (rotateGesture);
			showKittenImageView.AddGestureRecognizer (pinchGesture);
		}
	}
}

