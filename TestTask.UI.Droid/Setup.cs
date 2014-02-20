using Android.Content;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using TestTask.UI.Droid.CustomBinding;
using TestTask.UI.Droid.Controls;

namespace TestTask.UI.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App();
		}

		protected override System.Collections.Generic.IDictionary<string, string> ViewNamespaceAbbreviations
		{
			get
			{
				var toReturn = base.ViewNamespaceAbbreviations;
				toReturn["custom"] = "TestTask.UI.Droid.Controls";
				return toReturn;
			}
		}

		protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
		{
			registry.RegisterCustomBindingFactory<MvxProgressImageView>(
				"ImageLoaded", 
				binary => new MvxMyImageViewTargetBinding(binary) );
			base.FillTargetFactories(registry);
		}
	}
}

