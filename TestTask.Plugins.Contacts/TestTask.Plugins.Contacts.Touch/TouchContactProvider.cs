using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Xamarin.Contacts;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MessageUI;
using TestTask.DT;

namespace TestTask.Plugins.Contacts.Touch
{
	public class TouchContactProvider: IContacts
	{
		List<AddressContact> IContacts.GetContacts()
		{
			var ab = new AddressBook();

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
			string digitNumber = new string(number.Where(c => char.IsDigit(c)).ToArray());
			var call = NSUrl.FromString(@"tel://"+ digitNumber);
			if (UIApplication.SharedApplication.CanOpenUrl(call)) {
				var result = UIApplication.SharedApplication.OpenUrl(call);
				return result;
			} else {
				return false;
			}
		}

		public void SendEmail(string email, string subject, string cc, string emailText)
		{
			MFMailComposeViewController _mailController;
			_mailController = new MFMailComposeViewController ();
			_mailController.SetToRecipients (new string[]{email});
			_mailController.SetSubject (subject);
			_mailController.SetCcRecipients(new string[]{cc});
			_mailController.SetMessageBody (emailText, false);
			_mailController.Finished += ( object s, MFComposeResultEventArgs args) => {
				Console.WriteLine (args.Result.ToString ());
				args.Controller.DismissViewController (true, null);
			};
			var presenter = Mvx.Resolve<IMvxTouchViewPresenter> (); 
			presenter.PresentModalViewController (_mailController, false);
		}
	}
}

