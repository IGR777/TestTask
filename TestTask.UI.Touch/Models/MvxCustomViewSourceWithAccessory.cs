using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;

namespace TestTask.UI.Touch.Models
{
	public class MvxCustomViewSourceWithAccessory : MvxStandardTableViewSource
	{
		public MvxCustomViewSourceWithAccessory(UITableView tableView, string bindingText) : base(tableView, bindingText)
		{
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = base.GetCell (tableView, indexPath);
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}
	}
}

