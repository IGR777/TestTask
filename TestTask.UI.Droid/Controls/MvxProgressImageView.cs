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
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Android.Graphics;
using Android.Util;
using Cirrious.MvvmCross.Binding.Droid.ResourceHelpers;
using Cirrious.CrossCore.Core;

namespace TestTask.UI.Droid.Controls
{	

	public class MvxProgressImageView
		: ImageView
	{
		private readonly IMvxImageHelper<Bitmap> _imageHelper;

		public MvxProgressImageView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			if (!Mvx.TryResolve(out _imageHelper))
			{
				MvxTrace.Error(
					"No IMvxImageHelper registered - you must provide an image helper before you can use a MvxImageView");
			}
			else
			{
				_imageHelper.ImageChanged += ImageHelperOnImageChanged;
			}

			var typedArray = context.ObtainStyledAttributes(attrs,
				MvxAndroidBindingResource.Instance
				.ImageViewStylableGroupId);

			int numStyles = typedArray.IndexCount;
			for (var i = 0; i < numStyles; ++i)
			{
				int attributeId = typedArray.GetIndex(i);
				if (attributeId == MvxAndroidBindingResource.Instance.SourceBindId)
				{
					ImageUrl = typedArray.GetString(attributeId);
				}
			}
			typedArray.Recycle();
		}

		public MvxProgressImageView(Context context)
			: base(context)
		{
			if (!Mvx.TryResolve(out _imageHelper))
			{
				MvxTrace.Error(
					"No IMvxImageHelper registered - you must provide an image helper before you can use a MvxImageView");
			}
			else
			{
				_imageHelper.ImageChanged += ImageHelperOnImageChanged;
			}
		}

		public string ImageUrl
		{
			get
			{
				if (_imageHelper == null)
					return null;
				return _imageHelper.ImageUrl;
			}
			set
			{
				if (_imageHelper == null)
					return;
				_imageHelper.ImageUrl = value;
			}
		}

		public string DefaultImagePath
		{
			get { return _imageHelper.DefaultImagePath; }
			set { _imageHelper.DefaultImagePath = value; }
		}

		public string ErrorImagePath
		{
			get { return _imageHelper.ErrorImagePath; }
			set { _imageHelper.ErrorImagePath = value; }
		}

		[Obsolete("Use ImageUrl instead")]
		public string HttpImageUrl
		{
			get { return ImageUrl; }
			set { ImageUrl = value; }
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_imageHelper != null)
					_imageHelper.Dispose();
			}

			base.Dispose(disposing);
		}

		private bool _imageLoaded;
		public bool ImageLoaded
		{
			get { return _imageLoaded;}
			set { _imageLoaded = value;UpdateImageLoaded();}
		}

		private void ImageHelperOnImageChanged(object sender, MvxValueEventArgs<Bitmap> mvxValueEventArgs)
		{
			ImageLoaded = true;
			SetImageBitmap(mvxValueEventArgs.Value);
		}


		private bool _isUpdating;

		private void UpdateImageLoaded()
		{
			if (_isUpdating)
				return;

			var handler = ImageLoadedChanged;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		public event EventHandler ImageLoadedChanged;

		public void SetThat(int value)
		{
			_isUpdating = true;
			try
			{
				if(value ==0)
					ImageLoaded = false;
				if(value ==1)
					ImageLoaded = true;
			}
			finally
			{
				_isUpdating = false;
			}
		}
	}
}

