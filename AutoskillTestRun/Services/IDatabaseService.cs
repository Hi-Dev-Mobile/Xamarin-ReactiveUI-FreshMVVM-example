using System. Collections. Generic;

using AutoskillTestRun. Models;

namespace AutoskillTestRun. Services
{
	/// <summary>
    /// If you're only having one implementation of DatabaseService
	/// the interface is unnecessary, but wanted to give an example
	/// of best practices for more complicated situations.
    /// </summary>
    public interface IDatabaseService
    {
		List<Contact> GetContacts ();

		void UpdateContact ( Contact contact );

		List<Quote> GetQuotes ();

		void UpdateQuote ( Quote quote );
    }
}
