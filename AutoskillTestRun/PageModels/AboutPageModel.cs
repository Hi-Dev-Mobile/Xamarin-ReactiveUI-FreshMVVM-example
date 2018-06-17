using System;
using FreshMvvm;
using Xamarin.Forms;


namespace AutoskillTestRun. PageModels
{
	public class AboutPageModel: FreshBasePageModel
    {
		public Command CloseCommand {
			get => new Command ( async () => await CoreMethods. PopPageModel ( modal: true ) );
		}


        public AboutPageModel () {}
    }
}
