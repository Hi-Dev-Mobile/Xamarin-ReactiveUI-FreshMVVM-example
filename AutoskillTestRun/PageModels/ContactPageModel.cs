using System;
using PropertyChanged;
using FreshMvvm;
using AutoskillTestRun.Services;
using AutoskillTestRun.Models;
using Xamarin.Forms;

namespace AutoskillTestRun. PageModels
{
	[AddINotifyPropertyChangedInterface]
	public class ContactPageModel: FreshBasePageModel
    {
		IDatabaseService databaseService;

		public Contact Contact { get; set; }


		public Command SaveCommand {
			get => new Command ( async () =>
			{
				databaseService. UpdateContact ( contact: Contact );
				await CoreMethods. PopPageModel ( Contact );
			} );
		}

		public ContactPageModel (IDatabaseService databaseService)
        {
			this. databaseService = databaseService;
			this. WhenAny
				( action: HandleContactChanged,
				 properties: o => o. Contact );
        }

		public override void Init ( object initData )
		{
			if (initData != null)
				Contact = initData as Contact;
			else
				Contact = new Contact ();
		}

		void HandleContactChanged ( string propertyName )
        {
            //handles the property changed, nice
        }
    }
}
