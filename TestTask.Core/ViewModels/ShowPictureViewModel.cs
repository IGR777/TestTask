using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.Services;
using TestTask.Core.Models;

namespace TestTask.Core.ViewModels
{
	public class ShowPictureViewModel
		: MvxViewModel
	{

		public void Init(int id, string imageUrl)
		{
			_id = id;
			_imageUrl =imageUrl;
		}
		public ICommand EditCommand
		{
			get {return new MvxCommand(() => ShowViewModel<EditPictureViewModel> (new {id = Id, imageUrl = ImageUrl}));}
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

