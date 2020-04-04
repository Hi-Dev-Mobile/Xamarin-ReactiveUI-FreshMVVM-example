using System;
using PropertyChanged;
using FreshMvvm;
using AutoskillTestRun.Services;
using AutoskillTestRun.Models;
using Xamarin.Forms;
using ReactiveUI;
using System.Threading.Tasks;
using System. Reactive;

namespace AutoskillTestRun. PageModels
{

	public class ContactPageModel: FreshBasePageModel
    {
		IDatabaseService databaseService;

		public Contact Contact { get; set; }

		public ReactiveCommand<Unit, Unit> SaveCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> OpenMenuCommand { get; private set; }

        public ContactPageModel (IDatabaseService databaseService)
        {
            this. databaseService = databaseService;

			SaveCommand = ReactiveCommand
				. CreateFromTask ( Save );

			OpenMenuCommand = ReactiveCommand
				. Create ( () => App. ToggleMainMenu ( true ) );
        }


		public override void Init ( object initData )
		{
			if (initData != null)
				Contact = initData as Contact;
			else
				Contact = new Contact ();
		}


		async Task Save()
		{
			databaseService. UpdateContact ( contact: Contact );
            await CoreMethods. PopPageModel ( Contact );
		}
    }
}
