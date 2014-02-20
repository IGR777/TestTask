using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using System.Linq;
using System.Collections.Generic;
using TestTask.Plugins.Contacts;
using TestTask.Core.Models;

namespace TestTask.Core.ViewModels
{
	public class ContactsViewModel
		: MvxViewModel
	{
		private IContacts _contactsManager;
		private List<AddressContact> _originalContacts;
		public ContactsViewModel(IContacts contactsManager)
		{
			_contactsManager = contactsManager;
			_contacts = new List<AddressContact>(ReceiveContacts ());
			_originalContacts = _contacts;
			_spinnerItems =new List<SpinnerItem>() 
			{ 
				new SpinnerItem{Caption = "Sort Asc", Id=0},
				new SpinnerItem{Caption = "Sort Desc" , Id=1}
			};
			_selectedItem = _spinnerItems.FirstOrDefault ();
		}

		private List<AddressContact> _contacts;
		public List<AddressContact> Contacts
		{
			get{ return _contacts; }
			set 
			{ 
				_contacts = value;
				RaisePropertyChanged (() => Contacts);
				RaisePropertyChanged (() => IsEmpty);
			}
		}



		private List<SpinnerItem> _spinnerItems;
		public List<SpinnerItem> SpinnerItems
		{
			get{ return _spinnerItems; }
		}

		private SpinnerItem _selectedItem;
		public SpinnerItem SelectedItem
		{
			get { return _selectedItem;}
			set
			{
				_selectedItem = value;
				DoSearch ();
				RaisePropertyChanged(() => SelectedItem); 
			}
		}

		public string _search = "";
		public string Search
		{
			get { return _search; }
			set{
				_search = value;
				if (string.IsNullOrEmpty (_search)) {
					Contacts = _originalContacts;
				} else {
					DoSearch ();
				}
				RaisePropertyChanged(() => SelectedItem); 
			}
		}

		public bool IsEmpty
		{
			get {return Contacts.Count == 0; }
		}

		private IEnumerable<AddressContact> ReceiveContacts()
		{
			var contacts = _contactsManager.GetContacts();
			foreach (var contact in contacts) 
			{
				yield return new AddressContact {
					ID = contact.ID,
					Name = contact.Name,
					Phones = contact.Phones,
					Emails = contact.Emails
				};
			}
		}

		public bool MakeCall(string number)
		{	
			return _contactsManager.MakePhoneCall (number);
		}

		public void MakeEmail(string Name, string To)
		{ 
			ShowViewModel<EmailViewModel>(new {Name = Name, To = To});
		}

		public void DoSearch()
		{
			switch (SelectedItem.Id) 
			{
				case 0:
				Contacts = _originalContacts.Where (item => item.Name.IndexOf (Search,System.StringComparison.OrdinalIgnoreCase)>=0).OrderBy (item => item.Name).ToList ();
					break;
				case 1:
				Contacts = _originalContacts.Where (item => item.Name.IndexOf (Search,System.StringComparison.OrdinalIgnoreCase)>=0).OrderByDescending (item => item.Name).ToList ();
					break;
			}
		}
	}
}

