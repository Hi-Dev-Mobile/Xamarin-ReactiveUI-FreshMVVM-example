using System.Collections.ObjectModel;
using ReactiveUI;
using Xamarin.Forms;

using AutoskillTestRun.Models;
using AutoskillTestRun.Pages;
using AutoskillTestRun.Services;

namespace AutoskillTestRun. PageModels
{
	public class QuoteListPageModel: BasePageModel
    {
		IDatabaseService databaseService;

		public ObservableCollection<Quote> Quotes { get; set; }

		public ReactiveCommand AddCommand { get; private set; }
		public ReactiveCommand SelectedCommand { get; private set; }

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
                . Create ( async () => await CoreMethods. PushPageModel<QuotePageModel> () );

            SelectedCommand = ReactiveCommand
                . Create<SelectedItemChangedEventArgs> ( SelectedAction );
        }
  
        
        public override void ReverseInit ( object value )
        {
            var newQuote = value as Quote;

            if (!Quotes. Contains ( newQuote ))
                Quotes. Add ( newQuote );
        }


		async void SelectedAction(SelectedItemChangedEventArgs args)
		{
			var quote = args. SelectedItem as Quote;
			if (quote == null) return;
			
			var page = this. CurrentPage as QuoteListPage;
			page. DeselectListView ();
			await CoreMethods. PushPageModel<QuotePageModel> ( quote );
		}
	}
}
