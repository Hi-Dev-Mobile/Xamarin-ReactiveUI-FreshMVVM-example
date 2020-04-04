using System. Reactive;
using ReactiveUI;

namespace AutoskillTestRun. PageModels
{
	public class AboutPageModel: BasePageModel
    {
		public ReactiveCommand<Unit, Unit> CloseCommand { get; private set; }


		public AboutPageModel ()
		{
			CloseCommand = ReactiveCommand
				. CreateFromTask ( async () => await CoreMethods. PopPageModel ( modal: true ) );
		}
    }
}
