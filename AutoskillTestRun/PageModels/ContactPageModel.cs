using System;
using PropertyChanged;
using FreshMvvm;
using AutoskillTestRun.Services;
using AutoskillTestRun.Models;
using Xamarin.Forms;
using ReactiveUI;

namespace AutoskillTestRun. PageModels
{

	public class ContactPageModel: FreshBasePageModel
    {
		IDatabaseService databaseService;

		public Contact Contact { get; set; }

		public ReactiveCommand SaveCommand { get; private set; }
		public ReactiveCommand OpenMenuCommand { get; private set; }

        public ContactPageModel (IDatabaseService databaseService)
        {
            this. databaseService = databaseService;
            
            // turn this back on if you want realtime updates
			//this. WhenAny
			    //( action: HandleContactChanged,
                 //properties: o => o. Contact );


			SaveCommand = ReactiveCommand. Create ( async () =>
			{
				databaseService. UpdateContact ( contact: Contact );
				await CoreMethods. PopPageModel ( Contact );
			} );

			OpenMenuCommand = ReactiveCommand. Create ( () => App. ToggleMainMenu ( true ) );
        }


		public override void Init ( object initData )
		{
			if (initData != null)
				Contact = initData as Contact;
			else
				Contact = new Contact ();
		}

        // need here for model updater to work, also can do chores as needed
		void HandleContactChanged ( string propertyName ) {}
    }
}
