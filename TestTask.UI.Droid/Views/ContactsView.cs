using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using TestTask.Core.ViewModels;
using TestTask.Core.Models;
using Cirrious.MvvmCross.Binding.Droid.Views;

namespace TestTask.UI.Droid
{
	[Activity(Label = "Contacts")]
	public class ContactsView : MvxActivity
	{
		protected ListView contactsView = null;
		protected IMvxAdapter _adapter= null;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ContactsView);

			contactsView = FindViewById<ListView> (Resource.Id.lstContacts);
			if(contactsView != null) 
			{
				_adapter = (IMvxAdapter)contactsView.Adapter;
				contactsView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					PopupMenu menu = new PopupMenu (this, e.View);
					var item = (AddressContact)_adapter.GetRawItem(e.Position);
					var id = 0;
					foreach(var phone in item.Phones)
					{
						menu.Menu.Add(0
							,id++
							,0,"Call " + phone).SetTitleCondensed(phone);
					}
					foreach(var email in item.Emails)
					{
						menu.Menu.Add(1
							,id++
							,0,"Send email to " + email).SetTitleCondensed(email);
					}
					menu.MenuItemClick += (s1, arg1) => {
						switch(arg1.Item.GroupId)
						{
							case 0:
								ContactsViewModel.MakeCall(arg1.Item.TitleCondensedFormatted.ToString());
								break;
							case 1:
								ContactsViewModel.MakeEmail(item.Name, arg1.Item.TitleCondensedFormatted.ToString());
								break;
							default:
								throw new Exception();
						}
					};

					menu.Show ();
				};
			}
		}

		protected ContactsViewModel ContactsViewModel
		{
			get { return base.ViewModel as ContactsViewModel; }
		}
	}
}

