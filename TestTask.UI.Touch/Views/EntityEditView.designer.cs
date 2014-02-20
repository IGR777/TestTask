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
	[Register ("EntityEditView")]
	partial class EntityEditView
	{
		[Outlet]
		MonoTouch.UIKit.UITextField Description { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch IsActive { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField Name { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel nameValidation { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Description != null) {
				Description.Dispose ();
				Description = null;
			}

			if (IsActive != null) {
				IsActive.Dispose ();
				IsActive = null;
			}

			if (Name != null) {
				Name.Dispose ();
				Name = null;
			}

			if (nameValidation != null) {
				nameValidation.Dispose ();
				nameValidation = null;
			}
		}
	}
}
