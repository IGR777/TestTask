using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.Services;
using TestTask.Core.Models;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Plugins.Json;
using TestTask.Plugins.Notifications;

namespace TestTask.Core.ViewModels
{
	public class PicturesViewModel
		: MvxViewModel
	{
		private IKittenService _kittenManager;
		private IPicturesService _pictureManager;
		private INotifications _notificationManager;
		private int _itemCount = 10;

		public void Init(){
			var kittens = DeserializeKittens ();
			if (_pictureManager.IsRemoving) {
				kittens.RemoveAll (item => item.Id == _pictureManager.RemovingId);
				_notificationManager.DisplayNotification ("Kitten is removed");
				_pictureManager.IsRemoving = false;
			}
			if (_pictureManager.IsAdded) {
				_notificationManager.DisplayNotification ("This cutie's been saved on device");
				_pictureManager.IsAdded = false;
			}
			SetKittens (kittens);
		}

		public PicturesViewModel(IKittenService kittenService, IPicturesService pictureService,  INotifications notificationManager)
		{
			_pictureManager = pictureService;
			_kittenManager = kittenService;
			_notificationManager = notificationManager;
			if (!string.IsNullOrEmpty (_pictureManager.CachedString)) {
				Init ();
			} else {
				_items = new List<KittenViewModel> (GenerateKittens (_itemCount));
			}
		}

		private List<KittenViewModel> _items;
		public List<KittenViewModel> Items {
			get{ return _items; }
			set {
				_items = value;
				RaisePropertyChanged (() => Items);
			}
		}

		public Kitten GenerateKitten(int id)
		{
			return _kittenManager.CreateNewKitten(id);
		}

		public IEnumerable<KittenViewModel> GenerateKittens(int count)
		{
			for(int i=0;i<count;++i)
			{
				yield return new KittenViewModel(GenerateKitten(i));
			}
		}
		public ICommand ShowKittenCommand
		{
			get {return new MvxCommand<KittenViewModel> ((kitten) => {
					SerializeKittens();	
				    ShowViewModel<ShowPictureViewModel> (new {id = kitten.Kitten.Id, imageUrl = kitten.Kitten.ImageUrl } );
				}
				);}
		}

		public ICommand RefreshCommand
		{
			get {return new MvxCommand(() => RefreshKittens());}
		}

		private void RefreshKittens()
		{
			Items = new List<KittenViewModel>(GenerateKittens (_itemCount));
		}

		private List<Kitten> GetKittens()
		{
			return Items.Select (item => item.Kitten).ToList();
		}

		private void SetKittens(List<Kitten> kittens)
		{
			_items = new List<KittenViewModel> ();
			foreach (var kitten in kittens) {
				Items.Add (new KittenViewModel(kitten));
			}
		}

		private void SerializeKittens(){
			var items = GetKittens();
			var serializedString = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(items);
			_pictureManager.CachedString = serializedString;
		}

		private List<Kitten> DeserializeKittens(){
			var deserialized = Mvx.Resolve<IMvxJsonConverter>().DeserializeObject<List<Kitten>>( _pictureManager.CachedString);
			return deserialized;
		}
	}
}

