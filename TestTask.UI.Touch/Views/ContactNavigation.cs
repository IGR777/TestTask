using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.ViewModels;
using TestTask.UI.Touch.Models;

namespace TestTask.UI.Touch
{
	public class ContactNavigation : UITableViewController
	{
		UITableView tableView;
		List<ContactsNavGroup> navItems = new List<ContactsNavGroup>();
		List<string> phones;
		List<string> mails;
		string name;
		IMvxViewModel viewModel;
		public ContactNavigation (IMvxViewModel viewModel, List<string> phones, List<string> mails, string name) : base(UITableViewStyle.Grouped)
		{
			this.viewModel = viewModel;
			this.phones = phones;
			this.mails = mails;
			this.name = name;
		}

		public override void ViewDidLayoutSubviews ()
		{
			base.ViewDidLayoutSubviews ();
			tableView.Frame = View.Frame;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = name;
			ContactsNavGroup navGroup = new ContactsNavGroup ("Phones");
			navItems.Add (navGroup);
			foreach (var phone in phones) 
			{
				navGroup.Items.Add (new ContactsNavItem(phone, 0));
			}

			navGroup = new ContactsNavGroup ("Mails");
			navItems.Add (navGroup);
			foreach (var mail in mails) 
			{
				navGroup.Items.Add (new ContactsNavItem(mail, 1));
			}

			// create a table source from our nav items
			var tableSource = new ContactsNavTableSource (navItems, viewModel, name);

			// set the source on the table to our data source
			tableView = new UITableView ();
			tableView.Source = tableSource;
		
			View.Add (tableView);
		}
	}
}

