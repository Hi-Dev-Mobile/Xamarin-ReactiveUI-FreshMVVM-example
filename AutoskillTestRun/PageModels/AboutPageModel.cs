using System;
using FreshMvvm;
using Xamarin.Forms;
using ReactiveUI;


namespace AutoskillTestRun. PageModels
{
	public class AboutPageModel: BasePageModel
    {
		public ReactiveCommand CloseCommand { get; private set; }


		public AboutPageModel ()
		{
			CloseCommand = ReactiveCommand
				. Create ( async () => await CoreMethods. PopPageModel ( modal: true ) );
		}
    }
}
