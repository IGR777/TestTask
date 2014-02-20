using System;
using System.Collections.Generic;
using TestTask.DT;

namespace TestTask.Plugins.Contacts
{
	public interface IContacts
	{
		List<AddressContact> GetContacts ();
		bool MakePhoneCall (string number); 
		void SendEmail (string email, string subject, string cc, string emailText);
	}
}

