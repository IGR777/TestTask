package testtask.ui.droid;


public class ContactsView
	extends cirrious.mvvmcross.droid.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TestTask.UI.Droid.ContactsView, TestTask.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ContactsView.class, __md_methods);
	}


	public ContactsView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ContactsView.class)
			mono.android.TypeManager.Activate ("TestTask.UI.Droid.ContactsView, TestTask.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
