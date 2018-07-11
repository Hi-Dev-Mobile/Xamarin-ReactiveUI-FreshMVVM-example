namespace AutoskillTestRun. Pages
{
	public partial class QuoteListPage : BasePage
    {
        public QuoteListPage ()
        {
            InitializeComponent ();
        }

		// need to manually deselect items for ListViews
		public void DeselectListView()
		{
			ListView. SelectedItem = null;
		}
    }
}
