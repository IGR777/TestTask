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
	[Register ("EntityCell")]
	partial class EntityCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel entityName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel entityUpdated { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (entityName != null) {
				entityName.Dispose ();
				entityName = null;
			}

			if (entityUpdated != null) {
				entityUpdated.Dispose ();
				entityUpdated = null;
			}
		}
	}
}
