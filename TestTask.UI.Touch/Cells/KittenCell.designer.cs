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
	[Register ("KittenCell")]
	partial class KittenCell
	{
		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView imageProgress { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView KittenImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (KittenImageView != null) {
				KittenImageView.Dispose ();
				KittenImageView = null;
			}

			if (imageProgress != null) {
				imageProgress.Dispose ();
				imageProgress = null;
			}
		}
	}
}
