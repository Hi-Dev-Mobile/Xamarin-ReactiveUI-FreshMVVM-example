using System.Collections.ObjectModel;

using ReactiveUI;
using Xamarin.Forms;

using AutoskillTestRun.Models;
using AutoskillTestRun.Pages;
using AutoskillTestRun.Services;
using System. Reactive;

namespace AutoskillTestRun. PageModels
{
	public class QuoteListPageModel: BasePageModel
    {
		IDatabaseService databaseService;

		public ObservableCollection<Quote> Quotes { get; set; }

		public ReactiveCommand<Unit, Unit> AddCommand { get; private set; }
		public ReactiveCommand<SelectedItemChangedEventArgs, Unit> SelectedCommand { get; private set; }

		Quote selectedQuote;
		public Quote SelectedQuote {
			get => selectedQuote;
			set => this. RaiseAndSetIfChanged ( ref selectedQuote, value );
		}

        
		public QuoteListPageModel (IDatabaseService databaseService)
        {
			this.databaseService = databaseService;
			Quotes = new ObservableCollection<Quote> ( databaseService. GetQuotes () );         

            AddCommand = ReactiveCommand
                . CreateFromTask ( async () => await CoreMethods. PushPageModel<QuotePageModel> () );

            SelectedCommand = ReactiveCommand
                . Create<SelectedItemChangedEventArgs> ( SelectedAction );
        }
  
  
        // returns the object back to whoever pushed the pageModel
        public override void ReverseInit ( object returnedData )
        {
            var newQuote = returnedData as Quote;

            if (!Quotes. Contains ( newQuote ))
                Quotes. Add ( newQuote );
        }


		async void SelectedAction(SelectedItemChangedEventArgs args)
		{
			var quote = args. SelectedItem as Quote;
			if (quote == null) return;
			
			var page = CurrentPage as QuoteListPage;
			page. DeselectListView ();
			await CoreMethods. PushPageModel<QuotePageModel> ( quote );
		}
	}
}
