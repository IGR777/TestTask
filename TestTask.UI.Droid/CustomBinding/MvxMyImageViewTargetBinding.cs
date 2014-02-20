using System;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Droid.Target;
using TestTask.UI.Droid.Controls;

namespace TestTask.UI.Droid.CustomBinding
{
	public class MvxMyImageViewTargetBinding : MvxAndroidTargetBinding
	{
		protected  MvxProgressImageView MyImageView
		{
			get { return (MvxProgressImageView) Target; }
		}

		public MvxMyImageViewTargetBinding(MvxProgressImageView target) : base(target)
		{
		}

		public override void SubscribeToEvents()
		{
			MyImageView.ImageLoadedChanged += TargetOnImageLoadedChanged;
		}

		private void TargetOnImageLoadedChanged(object sender, EventArgs eventArgs)
		{
			var target = Target as MvxProgressImageView;

			if (target == null)
				return;
			FireValueChanged(target.ImageLoaded);
		}

		protected override void SetValueImpl(object target, object value)
		{
			var imageView = (MvxProgressImageView)target;
			imageView.SetThat((int)value);
		}

		public override Type TargetType
		{
			get { return typeof(int); }
		}

		public override MvxBindingMode DefaultMode
		{
			get { return MvxBindingMode.TwoWay; }
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				var target = Target as MvxProgressImageView;
				if (target != null)
				{
					target.ImageLoadedChanged -= TargetOnImageLoadedChanged;
				}
			}
			base.Dispose(isDisposing);
		}
	}
}