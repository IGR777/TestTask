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
	[Register ("ContactsView")]
	partial class ContactsView
	{
		[Outlet]
		MonoTouch.UIKit.UITableView contactTable { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISearchBar Search { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField sortTextView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (contactTable != null) {
				contactTable.Dispose ();
				contactTable = null;
			}

			if (Search != null) {
				Search.Dispose ();
				Search = null;
			}

			if (sortTextView != null) {
				sortTextView.Dispose ();
				sortTextView = null;
			}
		}
	}
}
