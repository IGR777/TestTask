package testtask.ui.droid;


public class ShowPictureView_ScaleListener
	extends android.view.ScaleGestureDetector.SimpleOnScaleGestureListener
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TestTask.UI.Droid.ShowPictureView/ScaleListener, TestTask.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ShowPictureView_ScaleListener.class, __md_methods);
	}


	public ShowPictureView_ScaleListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ShowPictureView_ScaleListener.class)
			mono.android.TypeManager.Activate ("TestTask.UI.Droid.ShowPictureView/ScaleListener, TestTask.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
