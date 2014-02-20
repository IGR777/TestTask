using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using TestTask.Core.Models;
using TestTask.Core.Services;
using TestTask.Plugins.Notifications;

namespace TestTask.Core.ViewModels
{
	
	public class EntitiesViewModel
		: MvxViewModel
	{

		private IDataService _entityManager;
		private IEntityService _entityService;
		private INotifications _notificationManager;
		public EntitiesViewModel(IDataService dataService, IEntityService entityService,INotifications notificationManager){
			_entityManager = dataService;
			_entityService = entityService;
			_notificationManager = notificationManager;
			Items = GetItems ();

			if (_entityService.IsAdded) {
				_notificationManager.DisplayNotification (string.Format("Entity {0} is added",_entityService.Name));
				_entityService.IsAdded = false;
			}
			if (_entityService.IsEdited) {
				_notificationManager.DisplayNotification (string.Format("Entity {0} was edited",_entityService.Name));
				_entityService.IsEdited = false;
			} 
		}

		private List<Entity> _items;
		public List<Entity> Items
		{
			get { return _items; }
			set { _items = value; RaisePropertyChanged(() => Items); }
		}

		public bool IsEmpty
		{
			get{return Items.Count == 0; }
		}

		public ICommand EditCommand
		{
			get 
			{ 
				return new MvxCommand<Entity> (entity => ShowViewModel<EntityEditViewModel> (new {
					ButtonText = "Update"
					, id = entity.Id
					, name = entity.Name
					, description = entity.Description
					, isActive = entity.IsActive})); 
			}
		}

		public ICommand AddCommand
		{
			get {return new MvxCommand (() => ShowViewModel<EntityEditViewModel> (new {ButtonText = "Add", id = 0})); }
		}

		public List<Entity> GetItems(){
			return _entityManager.GetItems ();
		}

	}
}

