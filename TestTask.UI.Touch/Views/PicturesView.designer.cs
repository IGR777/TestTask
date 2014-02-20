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
	[Register ("PicturesView")]
	partial class PicturesView
	{
		[Outlet]
		MonoTouch.UIKit.UITableView pictureTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (pictureTable != null) {
				pictureTable.Dispose ();
				pictureTable = null;
			}
		}
	}
}
