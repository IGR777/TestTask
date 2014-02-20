using System.Collections.Generic;
using System.Linq;
using Android.Provider;
using Android.Content;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using Xamarin.Contacts;
using Android.Graphics;
using Android.Net;
using Android.Telephony;
using TestTask.DT;

namespace TestTask.Plugins.Contacts.Droid
{
	public class DroidContactsProvider : MvxAndroidTask, IContacts
	{
		List<AddressContact> IContacts.GetContacts()
		{
			var globals = Mvx.Resolve<Cirrious.CrossCore.Droid.IMvxAndroidGlobals>();
			var ab = new AddressBook(globals.ApplicationContext);

			var allContacts = ab.ToList ();
			return allContacts.Select (item => new AddressContact {
				ID = item.Id,
				Name = item.DisplayName,
				Phones = item.Phones.Select(phone => phone.Number).ToList(),
				Emails = item.Emails.Select(mail => mail.Address).ToList()
			}).ToList();
		}

		public bool MakePhoneCall (string number) 
		{
			string text = PhoneNumberUtils.FormatNumber (number);
			Intent intent = new Intent ("android.intent.action.CALL", Uri.Parse ("tel:" + text));
			base.StartActivity (intent);
			return true;
		}

		public void SendEmail(string email, string subject, string cc, string emailText)
		{
			Intent intent = new Intent("android.intent.action.SENDTO");
			intent.SetType("text/html");
			intent.PutExtra("android.intent.extra.EMAIL", email);
			intent.PutExtra("android.intent.extra.SUBJECT", subject);
			intent.PutExtra("android.intent.extra.CC", cc);
			intent.PutExtra("android.intent.extra.TEXT", emailText);

			base.StartActivity(Intent.CreateChooser(intent, "Send Email..."));
		}
	}
}

