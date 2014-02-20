using System;
using System.Collections.Generic;

namespace TestTask.DT
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
	}
}