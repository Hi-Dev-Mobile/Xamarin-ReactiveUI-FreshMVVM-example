using System;
using FreshMvvm;
using ReactiveUI;
using PropertyChanged;
using AutoskillTestRun.Services;
using AutoskillTestRun.Models;
using Xamarin.Forms;

namespace AutoskillTestRun. PageModels
{
	public class QuotePageModel: FreshBasePageModel
    {
		IDatabaseService databaseService;

		public Quote Quote { get; set; }
        
		public ReactiveCommand SaveCommand { get; private set; }


		public QuotePageModel (IDatabaseService databaseService)
        {
			this. databaseService = databaseService;

			SaveCommand = ReactiveCommand. Create ( async () =>
			  {
				  databaseService. UpdateQuote ( Quote );
				  await CoreMethods. PopPageModel ( Quote );
			  } );
        }


		public override void Init ( object initData )
		{
			Quote = initData as Quote;
			if (Quote == null)
				Quote = new Quote ();
		}
	}
}
