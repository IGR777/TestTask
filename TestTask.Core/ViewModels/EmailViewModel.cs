using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using System.Windows.Input;
using TestTask.Plugins.Contacts;

namespace TestTask.Core.ViewModels
{
	public class EmailViewModel 
		: MvxViewModel
	{
		private IContacts _contactsManager;

		public void Init(string Name, string To)
		{
			this.To = To;
			EmailText = "Hello, " + Name;
			_contactsManager = Mvx.Resolve<IContacts>();
		}

		private string _to;
		public string To
		{
			get{ return _to;}
			set 
			{
				_to = value; 
				RaisePropertyChanged (() => To); 
			}
		}

		private string _cc="";
		public string CC
		{
			get{ return _cc;}
			set 
			{
				_cc = value; 
				RaisePropertyChanged (() => CC); 
			}
		}

		private string _subject="";
		public string Subject
		{
			get{ return _subject;}
			set 
			{
				_subject = value; 
				RaisePropertyChanged (() => Subject); 
			}
		}

		private string _emailText="";
		public string EmailText
		{
			get{ return _emailText;}
			set 
			{
				_emailText = value; 
				RaisePropertyChanged (() => EmailText); 
			}
		}

		public ICommand SendCommand
		{
			get { return new MvxCommand(() => SendEmail());}
		}

		public void SendEmail()
		{
			_contactsManager.SendEmail(To, Subject, CC, EmailText);
		}
	}
}

