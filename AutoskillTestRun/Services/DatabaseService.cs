using AutoskillTestRun. Models;
using System. Collections. Generic;


namespace AutoskillTestRun. Services
{
	/// <summary>
    /// Mock Database Service
    /// </summary>
	public class DatabaseService: IDatabaseService
    {
		private List<Contact> contacts;
		private List<Quote> quotes;
        
        public DatabaseService ()
        {
			contacts = InitContacts ();
			quotes = InitQuotes ();
        }
  

		public void UpdateContact(Contact contact)
		{
			if (contact.Id == 0) {
				contact. Id = contacts. Count + 1;
				contacts. Add ( contact );
			}
			else {
				var oldContact = contacts. Find ( c => c. Id == contact. Id );
				oldContact. Name = contact. Name;
				oldContact. Phone = contact. Phone;
			}
		}


		public void UpdateQuote(Quote quote)
		{
			if (quote.Id == 0) {
				quote. Id = quotes. Count + 1;
				quotes. Add ( quote );
			}
			else {
				var oldQuote = quotes. Find ( q => q. Id == quote. Id );
				oldQuote. CustomerName = quote. CustomerName;
				oldQuote. Total = quote. Total;
			}
		}

        
        public List<Contact> GetContacts ()
        {
			return contacts;
        }


        public List<Quote> GetQuotes ()
        {
			return quotes;
        }


		private List<Contact> InitContacts ()
        {
            return new List<Contact> {
                new Contact { Id = 1, Name = "Xam Consulting", Phone = "0404 865 350" },
                new Contact { Id = 2, Name = "Michael Ridland", Phone = "0404 865 350" },
                new Contact { Id = 3, Name = "Thunder Apps", Phone = "0404 865 350" },
            };
        }


        private List<Quote> InitQuotes ()
        {
            return new List<Quote> {
                new Quote { Id = 1, CustomerName = "Xam Consulting", Total = "$350.00" },
                new Quote { Id = 2, CustomerName = "Michael Ridland", Total = "$3503.00" },
                new Quote { Id = 3, CustomerName = "Thunder Apps", Total = "$3504.00" },
            };
        }
    }
}
