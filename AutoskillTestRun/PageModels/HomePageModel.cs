using PropertyChanged;
using System;

using AutoskillTestRun. Services;
using System.Collections.ObjectModel;
using AutoskillTestRun.Models;
using FreshMvvm;
using ReactiveUI;
using Xamarin.Forms;
using AutoskillTestRun.Pages;
using System.Reactive.Disposables;
using System.Reactive;
using System.Reactive.Linq;

namespace AutoskillTestRun. PageModels
{
	//[AddINotifyPropertyChangedInterface]
	public class HomePageModel: BasePageModel
    {
		IDatabaseService databaseService;

		CompositeDisposable disposeBag = new CompositeDisposable();

		public ObservableCollection<Contact> Contacts { get; set; }
  

		public ReactiveCommand AddCommand { get; private set; }
		public ReactiveCommand SelectedCommand { get; private set; }


        Contact selectedContact;
        public Contact SelectedContact
        {
            get => selectedContact;
            set => this. RaiseAndSetIfChanged ( ref selectedContact, value );
        }

        

		public HomePageModel (IDatabaseService databaseService)
		{
			this. databaseService = databaseService;
			Contacts = new ObservableCollection<Contact> ( databaseService. GetContacts () );
            
            AddCommand = ReactiveCommand
                .Create ( async () => await CoreMethods. PushPageModel<ContactPageModel> ());
                
            SelectedCommand = ReactiveCommand
                . Create<SelectedItemChangedEventArgs> (SelectedAction);
        }
             

        public override void ReverseInit ( object value )
        {
            var newContact = value as Contact;
            if (!Contacts. Contains ( newContact ))
                Contacts. Add ( newContact );
        }



        async void SelectedAction (SelectedItemChangedEventArgs args)
        {
			var contact = args.SelectedItem as Contact;
			
			if (contact == null) return;
			
			var page = CurrentPage as HomePage;
			page. DeselectListView ();
			await CoreMethods. PushPageModel<ContactPageModel> ( contact );

		}
    }
}
