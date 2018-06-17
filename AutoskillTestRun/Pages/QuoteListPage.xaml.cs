using System;
using System. Collections. Generic;

using Xamarin. Forms;

namespace AutoskillTestRun. Pages
{
	public partial class QuoteListPage : BasePage
    {
        public QuoteListPage ()
        {
            InitializeComponent ();
        }

		public void DeselectListView()
		{
			ListView. SelectedItem = null;
		}
    }
}
