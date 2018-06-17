using System;
using AutoskillTestRun.Models;
using System.Collections.Generic;

namespace AutoskillTestRun. Services
{
    public interface IDatabaseService
    {
		List<Contact> GetContacts ();

		void UpdateContact ( Contact contact );

		List<Quote> GetQuotes ();

		void UpdateQuote ( Quote quote );
    }
}
