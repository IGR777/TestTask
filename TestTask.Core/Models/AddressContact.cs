using System;
using System.Collections.Generic;

namespace TestTask.Core.Models
{
	public class AddressContact
	{
		public string ID;
		public string Name {get; set;}
		public List<string> Phones { get; set; }
		public List<string> Emails{ get; set; }

		public override string ToString ()
		{
			return Name;
		}

		public static implicit operator AddressContact(TestTask.DT.AddressContact contact)
		{
			return new AddressContact {
				ID = contact.ID,
				Name = contact.Name,
				Phones = contact.Phones,
				Emails = contact.Emails
			};
		}
	}
}

