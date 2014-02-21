package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	public static void LoadApplication (Context context, String runtimeDataDir, String[] apks)
	{
		synchronized (lock) {
			if (!initialized) {
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = context.getApplicationInfo ().dataDir + "/lib";
				ClassLoader loader  = context.getClassLoader ();

				Runtime.init (
						language,
						apks,
						runtimeDataDir,
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new java.io.File (
							android.os.Environment.getExternalStorageDirectory (),
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath (),
						MonoPackageManager_Resources.Assemblies);
				initialized = true;
			}
		}
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		"TestTask.UI.Droid.dll",
		"Cirrious.CrossCore.Droid.dll",
		"Cirrious.MvvmCross.Binding.Droid.dll",
		"Cirrious.CrossCore.dll",
		"Cirrious.MvvmCross.Binding.dll",
		"Cirrious.MvvmCross.Localization.dll",
		"Cirrious.MvvmCross.Droid.dll",
		"Cirrious.MvvmCross.dll",
		"Cirrious.MvvmCross.Plugins.File.dll",
		"Cirrious.MvvmCross.Plugins.File.Droid.dll",
		"Cirrious.MvvmCross.Plugins.Json.dll",
		"Newtonsoft.Json.dll",
		"Cirrious.MvvmCross.Plugins.Visibility.dll",
		"Cirrious.MvvmCross.Plugins.Visibility.Droid.dll",
		"Cirrious.MvvmCross.Plugins.DownloadCache.dll",
		"Cirrious.MvvmCross.Plugins.DownloadCache.Droid.dll",
		"Cirrious.MvvmCross.Community.Plugins.Sqlite.dll",
		"Cirrious.MvvmCross.Community.Plugins.Sqlite.Droid.dll",
		"TestTask.Core.dll",
		"TestTask.Plugins.Contacts.dll",
		"TestTask.Plugins.Contacts.Droid.dll",
		"TestTask.Plugins.Pictures.dll",
		"TestTask.Plugins.Pictures.Droid.dll",
		"TestTask.Plugins.Notifications.dll",
		"TestTask.Plugins.Notifications.Droid.dll",
		"TestTask.DT.dll",
		"Xamarin.Mobile.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_15";
}
