package testtask.ui.droid;


public class EntitiesView_ColorListViewAdapter
	extends cirrious.mvvmcross.binding.droid.views.MvxAdapter
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_getView:(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;:GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler\n" +
			"";
		mono.android.Runtime.register ("TestTask.UI.Droid.EntitiesView/ColorListViewAdapter, TestTask.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", EntitiesView_ColorListViewAdapter.class, __md_methods);
	}


	public EntitiesView_ColorListViewAdapter () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EntitiesView_ColorListViewAdapter.class)
			mono.android.TypeManager.Activate ("TestTask.UI.Droid.EntitiesView/ColorListViewAdapter, TestTask.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public EntitiesView_ColorListViewAdapter (android.content.Context p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == EntitiesView_ColorListViewAdapter.class)
			mono.android.TypeManager.Activate ("TestTask.UI.Droid.EntitiesView/ColorListViewAdapter, TestTask.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public android.view.View getView (int p0, android.view.View p1, android.view.ViewGroup p2)
	{
		return n_getView (p0, p1, p2);
	}

	private native android.view.View n_getView (int p0, android.view.View p1, android.view.ViewGroup p2);

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
