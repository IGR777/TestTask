using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using TestTask.Core.Models;

namespace TestTask.UI.Touch.Models
{
	public class MvxEntityViewSource : MvxStandardTableViewSource
	{
		public MvxEntityViewSource(UITableView tableView, string bindingText) : base(tableView, bindingText)
		{
			tableView.RegisterNibForCellReuse(UINib.FromName("EntityCell", NSBundle.MainBundle), EntityCell.Key);
		}

		protected override UITableViewCell GetOrCreateCellFor (UITableView tableView, NSIndexPath indexPath, object item)
		{
			var cellName = EntityCell.Key;	
			var cell =  (UITableViewCell)tableView.DequeueReusableCell(cellName, indexPath);						
			var entity = item as Entity;
			//cell.BackgroundColor = entity.IsActive ? UIColor.Green : UIColor.Gray;
			UIView cellBackgroundView = new UIView(new RectangleF(0, 0, cell.Bounds.Width, cell.Bounds.Height));
			cellBackgroundView.BackgroundColor = entity.IsActive ? UIColor.Green : UIColor.Gray;
			cell.BackgroundView = cellBackgroundView;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}    	

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return EntityCell.CellHeight();
		}
	}
}

