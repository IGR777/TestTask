using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TestTask.UI.Touch
{
	public static class HelperMethods
	{
		public static bool ReasignTextFieldResponder(UITextField field)
		{
			return field.ResignFirstResponder();
		}
	}
}

