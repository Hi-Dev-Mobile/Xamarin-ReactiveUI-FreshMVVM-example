using PropertyChanged;
using System;

using AutoskillTestRun. Services;
using System.Collections.ObjectModel;
using AutoskillTestRun.Models;
using FreshMvvm;
using Xamarin.Forms;
using AutoskillTestRun.Pages;

namespace AutoskillTestRun. PageModels
{
	//[AddINotifyPropertyChangedInterface]
	public class HomePageModel: FreshBasePageModel
    {
		IDatabaseService databaseService;
              
		public ObservableCollection<Contact> Contacts { get; set; }

		Contact selectedContact;
		public Contact SelectedContact
		{
			get => selectedContact;
			set {
				selectedContact = value;
				if (value != null) 
					ContactSelected. Execute ( selectedContact );
			}
		}

		public Command AddContact {
			get => new Command ( async () => await CoreMethods. PushPageModel<ContactPageModel> () );
		}

		public Command<Contact> ContactSelected
		{
			get => new Command<Contact> ( async ( contact ) =>
			{
				var page = CurrentPage as HomePage;
				page. DeselectListView ();
				await CoreMethods. PushPageModel<ContactPageModel> ( contact );
			});
		}
  


		public override void Init(object initData) 
		{
			Contacts = new ObservableCollection<Contact> ( databaseService. GetContacts () );
		}


		protected override void ViewIsAppearing ( object sender, EventArgs e )
		{
			base. ViewIsAppearing ( sender, e );
		}


		public override void ReverseInit ( object value )
		{
			var newContact = value as Contact;
			if (!Contacts. Contains ( newContact ))
				Contacts. Add ( newContact );
		}
        
		// init
		public HomePageModel (IDatabaseService databaseService)
        {
			this. databaseService = databaseService;
        }
    }
}
