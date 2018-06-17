using System;
using System. Collections. Generic;

using Xamarin. Forms;

namespace AutoskillTestRun. Pages
{
	public partial class HomePage : BasePage
    {
        public HomePage ()
        {
            InitializeComponent ();
        }


        public void DeselectListView()
		{
			ListView. SelectedItem = null;
		}
    }
}
