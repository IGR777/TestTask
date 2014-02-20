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
	[Register ("EditPictureView")]
	partial class EditPictureView
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView kittenImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton removeButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (removeButton != null) {
				removeButton.Dispose ();
				removeButton = null;
			}

			if (kittenImageView != null) {
				kittenImageView.Dispose ();
				kittenImageView = null;
			}
		}
	}
}
