using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using TestTask.Plugins.Contacts;
using TestTask.Plugins.Notifications;
using TestTask.Core.Services;

namespace TestTask.Core.ViewModels
{
	public class GrandViewModel 
		: MvxViewModel
	{
		public void Init(string currentTab){
			_currentTab = currentTab;
		}

		public GrandViewModel()
		{
			var notificationService = Mvx.Resolve<INotifications> ();
			Contacts = new ContactsViewModel(Mvx.Resolve<IContacts>());
			Pictures = new PicturesViewModel(Mvx.Resolve<IKittenService>(),Mvx.Resolve<IPicturesService>(),notificationService);
			Entities = new EntitiesViewModel(Mvx.Resolve<IDataService>(),Mvx.Resolve<IEntityService>(), notificationService);
			CoolPicture = new CoolPictureViewModel();
		}
		private ContactsViewModel _contacts;
		public ContactsViewModel Contacts
		{
			get { return _contacts; }
			set { _contacts = value; RaisePropertyChanged(() => Contacts); }
		}

		private PicturesViewModel _pictures;
		public PicturesViewModel Pictures
		{
			get { return _pictures; }
			set { _pictures = value; RaisePropertyChanged(() => Pictures); }
		}

		private EntitiesViewModel _entities;
		public EntitiesViewModel Entities
		{
			get { return _entities; }
			set { _entities = value; RaisePropertyChanged(() => Entities); }
		}

		private CoolPictureViewModel _coolPicture;
		public CoolPictureViewModel CoolPicture
		{
			get { return _coolPicture; }
			set { _coolPicture = value; RaisePropertyChanged(() => CoolPicture); }
		}

		private string _currentTab;
		public string CurrentTab{
			get{ return _currentTab;}
			set { _currentTab = value; }
		}
	}


}

