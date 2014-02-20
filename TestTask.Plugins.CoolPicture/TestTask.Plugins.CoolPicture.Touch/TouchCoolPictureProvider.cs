using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreGraphics;
using System.Reflection;

namespace TestTask.Plugins.CoolPicture.Touch
{
	public class TouchCoolPictureProvider : ICoolPicture
	{
		public void Rotate(string imagePath)
		{
			var _image = UIImage.FromBundle ("ImageBundle/kitten.jpg");
			UIImage Ret, Tmp;
			float newSide = Math.Max (_image.CGImage.Width, _image.CGImage.Height);// * src.CurrentScale;
			SizeF size = new SizeF (newSide, newSide);

			UIGraphics.BeginImageContext (size);
			CGContext context = UIGraphics.GetCurrentContext ();

			context.TranslateCTM(newSide/2, newSide/2);
			context.RotateCTM((float)Math.PI/2);
			_image.Draw( new RectangleF (-_image.CGImage.Width / 2, -_image.CGImage.Height / 2, newSide, newSide));

			Ret = UIGraphics.GetImageFromCurrentImageContext ();        

			UIGraphics.EndImageContext ();  // Restore context

			if (_image.CurrentScale != 1.0f)
			{
				Tmp = new UIImage (Ret.CGImage, _image.CurrentScale, UIImageOrientation.Up);
				Ret.Dispose ();
				var a = (Tmp);
			}

			Ret.SaveToPhotosAlbum((image, error) => {
				var o = image as UIImage;
			});
		}


		public void FlipHorizontal(string imagePath)
		{
		}

		public void FlipVertical(string imagePath)
		{
		}
	}
}

