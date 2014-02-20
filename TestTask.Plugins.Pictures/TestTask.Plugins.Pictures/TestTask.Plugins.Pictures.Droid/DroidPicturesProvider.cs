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
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using Android.Net;
using Java.IO;
using Android.Graphics;
using Uri = Android.Net.Uri;
using Environment = Android.OS.Environment;



namespace TestTask.Plugins.Pictures.Droid
{
	class DroidPicturesProvider :IPictures
	{
		public bool SaveToDevice(string imageUrl)
		{
			try{
				var globals = Mvx.Resolve<Cirrious.CrossCore.Droid.IMvxAndroidGlobals>();
				var cache = Mvx.Resolve<Cirrious.MvvmCross.Plugins.DownloadCache.IMvxImageCache<Bitmap>>();
				cache.RequestImage(imageUrl,	result=>{
					var _dir = new File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "Kittens");
					if (!_dir.Exists())
					{
						var res = _dir.Mkdirs();
					}
					Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
					//create a file to write bitmap data
					File f = new File(_dir, String.Format("Furry_{0}.jpg", Guid.NewGuid()));
					f.CreateNewFile();

					//Convert bitmap to byte array
					var bos = new System.IO.MemoryStream();
					result.Compress(Bitmap.CompressFormat.Png, 0 /*ignored for PNG*/, bos);
					byte[] bitmapdata = bos.ToArray();

					//write the bytes in file
					FileOutputStream fos = new FileOutputStream(f);
					fos.Write(bitmapdata);
					Uri contentUri = Uri.FromFile(f);
					mediaScanIntent.SetData(contentUri);
					globals.ApplicationContext.SendBroadcast(mediaScanIntent);
				},null);
				return true;
			} catch {
				return false;
			}
		}
	}
}

