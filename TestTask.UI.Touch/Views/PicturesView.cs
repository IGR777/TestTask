using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace TestTask.UI.Touch
{
	public partial class PicturesView : MvxViewController
	{
		public PicturesView () : base ("PicturesView", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public PicturesViewModel PicturesViewModel
		{
			get
			{
				return base.ViewModel as PicturesViewModel;
			}
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.

			var _rightButton = new UIBarButtonItem (UIBarButtonSystemItem.Refresh);
			_rightButton.Clicked += (object sender, EventArgs e) => PicturesViewModel.RefreshCommand.Execute (null);
			NavigationItem.RightBarButtonItem = _rightButton;

			var source = new KittenTableSource(pictureTable);
			pictureTable.Source = source;

			var set = this.CreateBindingSet<PicturesView, PicturesViewModel>();
			set.Bind(source).To(vm => vm.Items);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowKittenCommand);
			set.Apply();
		}

		public class KittenTableSource : MvxSimpleTableViewSource
		{
			public KittenTableSource(UITableView tableView)
				: base(tableView, "KittenCell", "KittenCell")
			{
			}

			public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return KittenCell.GetCellHeight();
			}
		}
	}
}

