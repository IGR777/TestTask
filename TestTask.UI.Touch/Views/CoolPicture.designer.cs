// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace TestTask.UI.Touch
{
	[Register ("CoolPicture")]
	partial class CoolPicture
	{
		[Outlet]
		MonoTouch.UIKit.UIButton flipHorButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton flipVertButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton rotateButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}

			if (rotateButton != null) {
				rotateButton.Dispose ();
				rotateButton = null;
			}

			if (flipHorButton != null) {
				flipHorButton.Dispose ();
				flipHorButton = null;
			}

			if (flipVertButton != null) {
				flipVertButton.Dispose ();
				flipVertButton = null;
			}
		}
	}
}
