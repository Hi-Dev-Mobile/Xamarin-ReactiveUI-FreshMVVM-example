using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using PropertyChanged;
using AutoskillTestRun.Services;
using AutoskillTestRun.Models;
using Xamarin.Forms;
using AutoskillTestRun.Pages;

namespace AutoskillTestRun. PageModels
{
	[AddINotifyPropertyChangedInterface]
	public class QuoteListPageModel: FreshBasePageModel
    {
		IDatabaseService databaseService;

		public ObservableCollection<Quote> Quotes { get; set; }

		Quote selectedQuote;
		public Quote SelectedQuote {
			get => selectedQuote;
			set {
				selectedQuote = value;
				if (value != null)
					QuoteSelected. Execute ( selectedQuote );
			}
		}

		public Command AddQuote {
			get => new Command ( async () => await CoreMethods. PushPageModel<QuotePageModel> () );
		}

		public Command<Quote> QuoteSelected {
			get => new Command<Quote> ( async ( quote ) => {

				var page = this. CurrentPage as QuoteListPage;
				page. DeselectListView ();
				await CoreMethods. PushPageModel<QuotePageModel> ( quote );
            } );
		}

		
        // init
		public QuoteListPageModel (IDatabaseService databaseService)
        {
			this.databaseService = databaseService;
        }

		public override void Init ( object initData )
		{
			Quotes = new ObservableCollection<Quote> ( databaseService. GetQuotes () );         
		}


		//protected override void ViewIsAppearing ( object sender, EventArgs e )
		//{
		//	base. ViewIsAppearing ( sender, e );
		//}      
		//protected override void ViewIsDisappearing ( object sender, EventArgs e )
		//{
		//	base. ViewIsDisappearing ( sender, e );
		//}


		public override void ReverseInit ( object value )
		{
			var newQuote = value as Quote;

			if (!Quotes. Contains ( newQuote ))
				Quotes. Add ( newQuote );
		}
	}
}
