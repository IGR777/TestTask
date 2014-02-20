using System;
using System.Collections.Generic;

namespace TestTask.UI.Touch.Models
{
	public class ContactsNavGroup
	{
		public string Name { get; set; }

		public string Footer { get; set; }

		public List<ContactsNavItem> Items
		{
			get { return items; }
			set { items = value; }
		}
		protected List<ContactsNavItem> items = new List<ContactsNavItem> ();

		public ContactsNavGroup (string name)
		{
			Name = name;
		}

	}
}

