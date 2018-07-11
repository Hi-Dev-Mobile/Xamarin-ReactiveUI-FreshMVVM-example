namespace AutoskillTestRun. Pages
{
	public partial class HomePage : BasePage
    {
        public HomePage ()
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
