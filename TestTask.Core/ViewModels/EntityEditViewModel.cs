using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.Services;
using TestTask.Core.Models;
using TestTask.Core.Helpers;

namespace TestTask.Core.ViewModels
{
	public class EntityEditViewModel
		: MvxViewModel
	{
		private IDataService _dataService;
		IEntityService _entityService;
		public EntityEditViewModel(IDataService dataService,IEntityService entityService)
		{
			_entityService = entityService;
			_dataService = dataService;
		}

		public void Init(string ButtonText, int id, string name, string description, bool isActive)
		{
			this.ButtonText = ButtonText;
			_id = id;
			_name = name ?? _name;
			_description = description ?? _description;
			_isActive = isActive;
		}

		private int _id;
		public int Id
		{
			get { return _id; }
		}

		private string _name="";
		public string Name
		{
			get { return _name; }
			set 
			{ 
				_name = value; 
				RaisePropertyChanged(() => Name); 
				Validate (); 
			}
		}

		private string _description="";
		public string Description
		{
			get { return _description; }
			set { _description = value; RaisePropertyChanged(() => Description); }
		}

		private bool _isActive;
		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value; RaisePropertyChanged(() => IsActive); }
		}

		public ICommand Proceed
		{
			get 
			{ 
				return new MvxCommand (() => {
					if(Validate())
					{
						ProceedEntity ();
						ShowViewModel<GrandViewModel> (new {currentTab = "2"});
					}
				});
			}
		}

		private string _buttonText;
		public string ButtonText
		{
			get { return _buttonText; }
			set { _buttonText = value; RaisePropertyChanged(() => ButtonText); }
		}
			
		public void ProceedEntity()
		{
			_entityService.Name = Name;
			if (Id == 0) {
				_dataService.Insert (new Entity{ Name = Name, Description = Description, IsActive = IsActive });
				_entityService.IsAdded = true;
			} else {
				_dataService.Update (new Entity {
					Id = Id,
					Name = Name,
					Description = Description,
					IsActive = IsActive,
					Updated = DateTime.Now
				});
				_entityService.IsEdited = true;
			}
		}

		//Validation part

		private ObservableDictionary<string, string> _errors = new ObservableDictionary<string, string>();
		public ObservableDictionary<string, string> Errors
		{
			get { return _errors; }
			set { _errors = value; RaisePropertyChanged(() => Errors); }
		}

		private bool Validate()
		{
			UpdateError(String.IsNullOrEmpty(Name), "Name", "Name is required");
			return Errors.Count == 0;
		}

		private void UpdateError(bool isInError, string propertyName, string errorMessage)
		{
			if (isInError)
			{
				Errors[propertyName] = errorMessage;
			}
			else
			{
				if (Errors.ContainsKey(propertyName))
					Errors.Remove(propertyName);
			}
		}
	}
}

