using System;
using FreshMvvm;
using PropertyChanged;
using AutoskillTestRun.Services;
using AutoskillTestRun.Models;
using Xamarin.Forms;

namespace AutoskillTestRun. PageModels
{
	[AddINotifyPropertyChangedInterface]
	public class QuotePageModel: FreshBasePageModel
    {
		IDatabaseService databaseService;

		public Quote Quote { get; set; }

		public Command SaveCommand {
			get => new Command ( async () =>
			{
				databaseService. UpdateQuote ( Quote );
				await CoreMethods. PopPageModel ( Quote );
			} );
		}

        



		public QuotePageModel (IDatabaseService databaseService)
        {
			this. databaseService = databaseService;
        }

		public override void Init ( object initData )
		{
			Quote = initData as Quote;
			if (Quote == null)
				Quote = new Quote ();
		}
	}
}
