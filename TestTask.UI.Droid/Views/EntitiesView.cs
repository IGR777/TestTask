using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using TestTask.Core.ViewModels;
using TestTask.Core.Models;
using Cirrious.MvvmCross.Binding.Droid;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Android.Graphics;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace TestTask.UI.Droid
{
	[Activity(Label = "Entities")]
	public class EntitiesView : MvxActivity
	{
		protected MvxListView entView = null;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.EntitiesView);


			entView = FindViewById<MvxListView> (Resource.Id.entitesView);
			//	Create adapter for overriding item color
			var _adapter = new ColorListViewAdapter(this,this.BindingContext as IMvxAndroidBindingContext);
			_adapter.ItemsSource = EntitiesViewModel.GetItems();
			// Get template for item
			_adapter.ItemTemplateId = (entView.Adapter as IMvxAdapter).ItemTemplateId;
			var existAdapter = entView.Adapter;
			entView.Adapter = _adapter;

			this.CreateBinding (_adapter).To<EntitiesViewModel> (vm => vm.Items).Apply();
			this.CreateBinding(entView).For("ItemClick").To<EntitiesViewModel> (vm => vm.EditCommand).Apply();
		}
		protected EntitiesViewModel EntitiesViewModel
		{
			get { return base.ViewModel as EntitiesViewModel; }
		}

		public class ColorListViewAdapter : MvxAdapter
		{

			public ColorListViewAdapter(Context context) : base(context)
			{
			}

			public ColorListViewAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext)
			{
			}

			public override View GetView (int position, View convertView, ViewGroup parent)
			{
				var v = base.GetView(position, convertView, parent);
				var entity = GetRawItem (position) as TestTask.Core.Models.Entity;
				v.SetBackgroundColor( entity.IsActive ? Color.Green : Color.Gray);
				return v;
			}
		}
	}
}

