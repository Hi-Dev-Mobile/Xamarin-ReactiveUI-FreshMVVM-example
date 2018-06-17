using System;
using FreshMvvm;
using Xamarin.Forms;

namespace AutoskillTestRun. PageModels
{
	public class MainMenuPageModel: FreshBasePageModel
    {
		public Command ShowAbout {
			get => new Command ( async () => await CoreMethods. PushPageModel<AboutPageModel> ( null, modal: true ) );
		}
        

		public MainMenuPageModel () {}
    }
}
