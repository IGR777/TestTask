using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using TestTask.Core.Models;

namespace TestTask.UI.Touch
{
	public partial class EntityCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("EntityCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("EntityCell");

		public EntityCell (IntPtr handle) : base (handle)
		{
			Initialise();
		}

		public static EntityCell Create ()
		{
			return (EntityCell)Nib.Instantiate (null, null) [0];
		}
			
		public static float CellHeight ()
		{
			return 60f;	
		}

		private void Initialise()
		{
			this.DelayBind (() =>
				{
					var bindings = this.CreateBindingSet<EntityCell, Entity>();
					bindings.Bind(entityName).To(m=>m.Name);
					bindings.Bind(entityUpdated).To(m=>m.Updated).WithConversion("TimeAgo");
					bindings.Apply();
				});

		}

	
	}
}

