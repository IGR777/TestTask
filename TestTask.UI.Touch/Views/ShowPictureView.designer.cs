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
	[Register ("ShowPictureViewModel")]
	partial class ShowPictureView
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView showKittenImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (showKittenImageView != null) {
				showKittenImageView.Dispose ();
				showKittenImageView = null;
			}
		}
	}
}
