using System.Threading.Tasks;

using FreshMvvm;
using ReactiveUI;

using AutoskillTestRun.Services;
using AutoskillTestRun.Models;


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

			SaveCommand = ReactiveCommand
				. CreateFromTask ( Save );
        }


		public override void Init ( object initData )
		{
			Quote = initData as Quote;
			if (Quote == null)
				Quote = new Quote ();
		}


		async Task Save()
		{
			databaseService. UpdateQuote ( Quote );
            await CoreMethods. PopPageModel ( Quote );
		}
	}
}
