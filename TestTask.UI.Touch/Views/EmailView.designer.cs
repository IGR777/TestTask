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
	[Register ("EmailView")]
	partial class EmailView
	{
		[Outlet]
		MonoTouch.UIKit.UITextField Cc { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField EmailTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField Subject { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField To { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (To != null) {
				To.Dispose ();
				To = null;
			}

			if (Cc != null) {
				Cc.Dispose ();
				Cc = null;
			}

			if (EmailTextField != null) {
				EmailTextField.Dispose ();
				EmailTextField = null;
			}

			if (Subject != null) {
				Subject.Dispose ();
				Subject = null;
			}
		}
	}
}
