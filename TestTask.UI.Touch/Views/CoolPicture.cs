using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.ViewModels;
using MonoTouch.CoreGraphics;

namespace TestTask.UI.Touch
{
	public partial class CoolPicture : MvxViewController
	{
		public CoolPicture () : base ("CoolPicture", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public CoolPictureViewModel CoolPictureViewModel
		{
			get
			{
				return base.ViewModel as CoolPictureViewModel;
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			//this.CreateBinding(imageView.Image.).To<CoolPictureViewModel>(model => model.RotateCommand).Apply();
			rotateButton.TouchDown+= (object sender, EventArgs e) => {
				imageView.Image = Rotate(imageView.Image);
				imageView.ContentMode = UIViewContentMode.ScaleToFill;
			};
			flipVertButton.TouchDown+= (object sender, EventArgs e) => {
				imageView.Image = FlipVertical(imageView.Image);
				imageView.ContentMode = UIViewContentMode.ScaleToFill;
			};

			flipHorButton.TouchDown+= (object sender, EventArgs e) => {
				imageView.Image = FlipHorizontal(imageView.Image);
				imageView.ContentMode = UIViewContentMode.ScaleToFill;
			};
		}

		public UIImage Rotate(UIImage _image)
		{
			UIImage Ret;
			float newSide = Math.Max (_image.CGImage.Width, _image.CGImage.Height);// * src.CurrentScale;
			SizeF size = new SizeF (newSide, newSide);

			UIGraphics.BeginImageContext (size);
			CGContext context = UIGraphics.GetCurrentContext ();

			context.TranslateCTM(newSide/2, newSide/2);
			context.RotateCTM((float)Math.PI/2);
			_image.Draw( new RectangleF (-_image.CGImage.Width / 2, -_image.CGImage.Height / 2, newSide, newSide));

			Ret = UIGraphics.GetImageFromCurrentImageContext ();        
			return Ret;
		}

		public UIImage FlipVertical(UIImage _image)
		{
			UIImage Ret;
			float newSide = Math.Max (_image.CGImage.Width, _image.CGImage.Height);// * src.CurrentScale;
			SizeF size = new SizeF (newSide, newSide);

			UIGraphics.BeginImageContext (size);
			CGContext context = UIGraphics.GetCurrentContext ();

			CGAffineTransform flipVertical = CGAffineTransform.MakeScale (1, -1);
			context.ConcatCTM(flipVertical);  

			_image.Draw( new RectangleF (0, -_image.CGImage.Height, newSide, newSide));

			Ret = UIGraphics.GetImageFromCurrentImageContext ();        
			return Ret;
		}

		public UIImage FlipHorizontal(UIImage _image)
		{
			UIImage Ret;
			float newSide = Math.Max (_image.CGImage.Width, _image.CGImage.Height);// * src.CurrentScale;
			SizeF size = new SizeF (newSide, newSide);

			UIGraphics.BeginImageContext (size);
			CGContext context = UIGraphics.GetCurrentContext ();

			CGAffineTransform flipVertical = CGAffineTransform.MakeScale (-1, 1);
			context.ConcatCTM(flipVertical);  

			_image.Draw( new RectangleF (-newSide, 0, newSide, newSide));

			Ret = UIGraphics.GetImageFromCurrentImageContext ();        
			return Ret;
		}
	}
}

