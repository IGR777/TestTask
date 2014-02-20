using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using TestTask.Core.ViewModels;

namespace TestTask.UI.Touch
{
	[Register("GrandView")]
	public sealed class GrandView : MvxTabBarViewController
	{
		public GrandView()
		{
			// need this additional call to ViewDidLoad because UIkit creates the view before the C# hierarchy has been constructed
			ViewDidLoad();
		}

		private GrandViewModel GrandViewModel
		{ get { return base.ViewModel as GrandViewModel; } }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// ios7 layout
//            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
//                EdgesForExtendedLayout = UIRectEdge.None;

			if (ViewModel == null)
				return;

			var viewControllers = new UIViewController[]
			{
				CreateTabFor("Contacts", "contacts", GrandViewModel.Contacts),
				CreateTabFor("Pictures", "pictures", GrandViewModel.Pictures),
				CreateTabFor("Entities", "entities", GrandViewModel.Entities),
				CreateTabFor("Cool picture", "coolPicture", GrandViewModel.CoolPicture)
			};
			ViewControllers = viewControllers;
			CustomizableViewControllers = new UIViewController[] { };

			if (!string.IsNullOrEmpty (GrandViewModel.CurrentTab)) {
				int outVal;
				int.TryParse (GrandViewModel.CurrentTab, out outVal);
				SelectedViewController = outVal!=0? ViewControllers [outVal]: ViewControllers [0];
			} else {
				SelectedViewController = ViewControllers [0];
			}
		}

		private int _createdSoFarCount = 0;

		private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
		{
			var controller = new UINavigationController();
			var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
			SetTitleAndTabBarItem(screen, title, imageName);
			controller.PushViewController(screen, false);
			return controller;
		}

		private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
		{
			screen.Title = title;
			screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle("Images/Tabs/" + imageName + ".png"),
				_createdSoFarCount);
			_createdSoFarCount++;
		}
			
	}
}

