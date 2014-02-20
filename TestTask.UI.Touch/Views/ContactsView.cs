using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.Models;
using TestTask.Core.ViewModels;
using TestTask.UI.Touch.Models;


namespace TestTask.UI.Touch
{
	public partial class ContactsView : MvxViewController
	{
		public ContactsView () : base ("ContactsView", null)
		{
		}

		private ContactsViewModel ContactsViewModel
		{ get { return base.ViewModel as ContactsViewModel; } }

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
			
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var source = new MvxCustomViewSourceWithAccessory(contactTable, "TitleText .");
			contactTable.Source = source;
			source.SelectedItemChanged += (object sender, EventArgs e) => {
				var item = source.SelectedItem as AddressContact;
				if(item!=null)
				{
					this.NavigationController.PushViewController(new ContactNavigation(ContactsViewModel,item.Phones, item.Emails, item.Name), true);
				}
				
			};
			// Perform any additional setup after loading the view, typically from a nib.

			// setup sort picker
			var anotherPicker = new UIPickerView ();
			var pickerViewModel = new MvxPickerViewModel(anotherPicker);
			anotherPicker.Model = pickerViewModel;
			anotherPicker.ShowSelectionIndicator = true;

			// Setup the toolbar for done button
			UIToolbar toolbar = new UIToolbar();
			toolbar.BarStyle = UIBarStyle.Black;
			toolbar.Translucent = true;
			toolbar.SizeToFit();

			// Create a 'done' button for the toolbar and add it to the toolbar
			UIBarButtonItem doneButton = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done,
				(s, e) => {
					this.sortTextView.ResignFirstResponder();
				});
			toolbar.SetItems(new UIBarButtonItem[]{doneButton}, true);


			sortTextView.InputView = anotherPicker;
			sortTextView.BorderStyle = UITextBorderStyle.RoundedRect;


			// Display the toolbar over the pickers
			this.sortTextView.InputAccessoryView = toolbar;

			this.CreateBinding(pickerViewModel).For(p => p.SelectedItem).To<ContactsViewModel>(vm => vm.SelectedItem).Apply();
			this.CreateBinding(pickerViewModel).For(p => p.ItemsSource).To<ContactsViewModel>(vm => vm.SpinnerItems).Apply();
			this.CreateBinding(source).To<ContactsViewModel>(vm => vm.Contacts).Apply();
			this.CreateBinding(sortTextView).To<ContactsViewModel>(vm => vm.SelectedItem).Apply();
			this.CreateBinding(Search).To<ContactsViewModel>(vm => vm.Search).Apply();


			this.Search.SearchButtonClicked += (object sender, EventArgs e) => {
				Search.ResignFirstResponder();
			};

		}
			
	}
}

