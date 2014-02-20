using System;
using Cirrious.CrossCore.IoC;

namespace TestTask.Core
{
	public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			RegisterAppStart<ViewModels.GrandViewModel>();
		}
	}
}

