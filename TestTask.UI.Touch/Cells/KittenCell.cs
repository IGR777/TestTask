using System;
using System.Drawing;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.CrossCore.Core;
using TestTask.Core.ViewModels;

namespace TestTask.UI.Touch
{
	public partial class KittenCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("KittenCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("KittenCell");

		public static KittenCell Create ()
		{
			return (KittenCell)Nib.Instantiate (null, null) [0];
		}


		private MvxProgressImageViewLoader _imageHelper;

		public KittenCell()
		{
			Initialise ();
		}

		public KittenCell(IntPtr handle)
			: base(handle)
		{
			Initialise ();
		}

		public string ImageUrl
		{
			get { return _imageHelper.ImageUrl; }
			set { 
				_imageHelper.ImageUrl = value; 
				_imageHelper.ImageChanged += (sender, mvxValueEventArgs) => {
					imageProgress.Hidden = true;
				};
			}
		}

		public static float GetCellHeight()
		{
			return 120f;
		}
			

		private void Initialise()
		{
			_imageHelper = new MvxProgressImageViewLoader (() => KittenImageView);
		
			this.DelayBind(() =>
				{
					this.CreateBinding().For((cell) => cell.ImageUrl).To<KittenViewModel>(model => model.Kitten.ImageUrl).Apply();
				});
					
		}


	}

	public class MvxProgressImageViewLoader:MvxImageViewLoader
	{
		public EventHandler ImageChanged;

		public MvxProgressImageViewLoader(Func<UIImageView> imageViewAccess, Action afterImageChangeAction = null) : base(imageViewAccess,afterImageChangeAction)
		{
		}

		public override void ImageHelperOnImageChanged (object sender, MvxValueEventArgs<UIImage> mvxValueEventArgs)
		{
			base.ImageHelperOnImageChanged (sender, mvxValueEventArgs);
			if (ImageChanged != null) {
				ImageChanged.Invoke (sender, mvxValueEventArgs);
			}
		}
	}
}

