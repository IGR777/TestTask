using System;

namespace TestTask.UI.Touch.Models
{
	public class ContactsNavItem
	{		
		public string Name
		{
			get 
			{ 
				return _groupId==0 ? "Call " + _name: "Send email to "+ _name; 
			}
			set { _name = value; }
		}
		protected string _name;

		public string Value
		{
			get { return _name;}
		}

		public int GroupId
		{
			get { return _groupId; }
			set { _groupId = value; }
		}
		protected int _groupId;

		public ContactsNavItem ( string name, int groupId)
		{
			this.Name = name;
			this.GroupId = groupId;
		}

	}
}

