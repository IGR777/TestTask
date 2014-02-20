using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.ViewModels;

namespace TestTask.UI.Touch.Models
{
	public class ContactsNavTableSource: UITableViewSource
	{
		protected List<ContactsNavGroup> navItems;
		string cellIdentifier = "ContactsNavTableCellView";
		private IMvxViewModel viewModel;
		private string contactName;
		public ContactsNavTableSource (List<ContactsNavGroup> items, IMvxViewModel viewModel, string name)
		{
			navItems = items;
			this.viewModel = viewModel;
			this.contactName = name;
		}

		/// <summary>
		/// Called by the TableView to determine how many sections(groups) there are.
		/// </summary>
		public override int NumberOfSections (UITableView tableView)
		{
			return navItems.Count;
		}

		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override int RowsInSection (UITableView tableview, int section)
		{
			return navItems[section].Items.Count;
		}

		/// <summary>
		/// Called by the TableView to retrieve the header text for the particular section(group)
		/// </summary>
		public override string TitleForHeader (UITableView tableView, int section)
		{
			return navItems[section].Name;
		}

		/// <summary>
		/// Called by the TableView to retrieve the footer text for the particular section(group)
		/// </summary>
		public override string TitleForFooter (UITableView tableView, int section)
		{
			return navItems[section].Footer;
		}

		/// <summary>
		/// Called by the TableView to actually build each cell. 
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// declare vars
			ContactsNavItem navItem = navItems[indexPath.Section].Items[indexPath.Row];

			var cell = tableView.DequeueReusableCell (this.cellIdentifier);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, this.cellIdentifier);
				cell.Tag = Environment.TickCount;
			}

			// set the cell properties
			cell.TextLabel.Text = navItems[indexPath.Section].Items[indexPath.Row].Name;
			cell.Accessory = UITableViewCellAccessory.None;

			// return the cell
			return cell;
		}


		/// <summary>
		/// Is called when a row is selected
		/// </summary>
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			// get a reference to the nav item
			ContactsNavItem navItem = navItems[indexPath.Section].Items[indexPath.Row];
			var executor = viewModel as ContactsViewModel;
			switch (navItem.GroupId) 
			{
				case 0:
					var result = executor.MakeCall (navItem.Value);
					if (!result) {
						new UIAlertView ("Failure", "Device couldn't make a call..", null, "OK", null).Show ();
					}
					break;
				case 1:
					executor.MakeEmail (contactName, navItem.Value);
					break;
			}


		}
	}
}

