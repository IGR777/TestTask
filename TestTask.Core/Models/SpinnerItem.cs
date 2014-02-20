using System;

namespace TestTask.Core
{
	public class SpinnerItem
	{
		public int Id{ get; set; }
		public string Caption{ get; set; }

		public override string ToString()
		{
			return Caption;
		}
	}
}

