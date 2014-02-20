using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.Services;
using TestTask.Core.Models;

namespace TestTask.Core.ViewModels
{
	public class KittenViewModel
		:MvxViewModel
	{
		public KittenViewModel (Kitten kitten)
		{
			_kitten = kitten;
		}

		private Kitten _kitten;
		public Kitten Kitten{
			get{ return _kitten; }
			set {_kitten = value; RaisePropertyChanged(() => Kitten);}
		}

		private bool _isLoaded;
		public bool IsLoaded {
			get{ return _isLoaded; }
			set {
				_isLoaded = value;
				RaisePropertyChanged (() => IsLoaded);
			}
		}
	}
}

