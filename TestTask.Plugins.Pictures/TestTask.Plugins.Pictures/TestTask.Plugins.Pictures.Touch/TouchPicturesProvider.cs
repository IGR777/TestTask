using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TestTask.Plugins.Pictures.Touch
{
	public class TouchPicturesProvider : IPictures
	{
		public bool SaveToDevice(string imageUrl)
		{
			try
			{
				var url = new NSUrl (imageUrl);
				var data = NSData.FromUrl (url);
				var someImage = UIImage.LoadFromData (data);
				someImage.SaveToPhotosAlbum((image, error) => {
				});
				return true;
			} catch{
				return false;
			}
		}
	}
}

