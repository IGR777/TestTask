using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.Services;
using TestTask.Core.Models;
using TestTask.Plugins.Pictures;
using TestTask.Plugins.Notifications;

namespace TestTask.Core.ViewModels
{
	public class EditPictureViewModel
		: MvxViewModel
	{
		private IPictures _pictureManager;
		private IPicturesService _pictureService;
		private INotifications _notificationManager;
		public void Init(int id, string imageUrl)
		{
			_id = id;
			_imageUrl =imageUrl;
		}

		public EditPictureViewModel(IPictures pictureManager, IPicturesService pictureService, INotifications notificationManager)
		{
			_pictureManager = pictureManager;
			_pictureService = pictureService;
			_notificationManager = notificationManager;
		}

		public ICommand SaveCommand
		{
			get {return new MvxCommand(() => {
				_pictureService.IsAdded = _pictureManager.SaveToDevice(ImageUrl);
				if(_pictureService.IsAdded){
					ShowViewModel<GrandViewModel> (new {currentTab = "1"});
				} else{
					_notificationManager.DisplayNotification("Failed to save kitty to device");
				}
			}
			);}
		}

		public ICommand RemoveCommand
		{
			get {return new MvxCommand (() => {
				_pictureService.IsRemoving = true;
				_pictureService.RemovingId = Id;
				ShowViewModel<GrandViewModel> (new {currentTab = "1"});
			}
			);}
		}

		private int _id;
		public int Id {
			get{ return _id; }
			set {
				_id = value;
				RaisePropertyChanged (() => Id);
			}
		}

		private string _imageUrl;
		public string ImageUrl {
			get{ return _imageUrl; }
			set {
				_imageUrl = value;
				RaisePropertyChanged (() => ImageUrl);
			}
		}

	}
}
