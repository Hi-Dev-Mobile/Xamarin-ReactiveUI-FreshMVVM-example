using System;
using Xamarin.Forms;


namespace AutoskillTestRun
{
	public class BasePage: ContentPage
    {      
		protected override void OnAppearing ()
		{
			base. OnAppearing ();

			var basePageModel = this. BindingContext as FreshMvvm. FreshBasePageModel;
			if (basePageModel == null) return;

			if (basePageModel.IsModalAndHasPreviousNavigationStack()) {
				if (ToolbarItems.Count > 2) {
					var closeModal = new ToolbarItem ( name: "Close Modal", 
					                                   icon: "", 
					                                   activated: () => basePageModel. CoreMethods. PopModalNavigationService () );
					ToolbarItems. Add ( closeModal );
				}
			}         
		}      
	}
}
