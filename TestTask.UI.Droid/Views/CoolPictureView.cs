using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using TestTask.Core.ViewModels;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace TestTask.UI.Droid
{
	[Activity(Label = "Cool picture")]
	public class CoolPictureView : MvxActivity
	{
		Button butRotate = null;
		Button butFlipHor = null;
		Button butFlipVert = null;
		ImageView imgView = null;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.CoolPictureView);

			imgView = FindViewById<ImageView> (Resource.Id.coolPictureImageView);
			butRotate = FindViewById<Button> (Resource.Id.rotateButton);
			butFlipHor = FindViewById<Button> (Resource.Id.flipHorButton);
			butFlipVert = FindViewById<Button> (Resource.Id.flipVertButton);

			imgView.SetImageResource (Resource.Drawable.kitten);

			butRotate.Click+= (object sender, System.EventArgs e) => {
				BitmapDrawable bitmapDrawable = ((BitmapDrawable) imgView.Drawable);
				imgView.SetImageBitmap(Rotate(bitmapDrawable.Bitmap));
			};

			butFlipHor.Click+= (object sender, System.EventArgs e) => {
				BitmapDrawable bitmapDrawable = ((BitmapDrawable) imgView.Drawable);
				imgView.SetImageBitmap(FlipHorizontal(bitmapDrawable.Bitmap));
			};


			butFlipVert.Click+= (object sender, System.EventArgs e) => {
				BitmapDrawable bitmapDrawable = ((BitmapDrawable) imgView.Drawable);
				imgView.SetImageBitmap(FlipVertical(bitmapDrawable.Bitmap));
			};
		}

		private Bitmap Rotate(Bitmap _image)
		{
			Matrix matrix = new Matrix();
			matrix.PostRotate(90);

			Bitmap rotated = Bitmap.CreateBitmap(_image, 0, 0, _image.Width, _image.Height,
				matrix, true);

			return rotated;
		}

		private Bitmap FlipVertical(Bitmap _image)
		{
			Matrix matrix = new Matrix();
			matrix.PostScale (1, -1);

			Bitmap rotated = Bitmap.CreateBitmap(_image, 0, 0, _image.Width, _image.Height,
				matrix, true);

			return rotated;
		}

		private Bitmap FlipHorizontal(Bitmap _image)
		{
			Matrix matrix = new Matrix();
			matrix.PostScale (-1, 1);

			Bitmap rotated = Bitmap.CreateBitmap(_image, 0, 0, _image.Width, _image.Height,
				matrix, true);

			return rotated;
		}
	}
}