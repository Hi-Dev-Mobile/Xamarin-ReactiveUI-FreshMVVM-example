using ReactiveUI;


namespace AutoskillTestRun. PageModels
{
	public class OnboardingPageModel: BasePageModel
    {
		public ReactiveCommand DismissCommand { get; private set; }

        public OnboardingPageModel ()
        {
			DismissCommand = ReactiveCommand. Create ( DismissPage );
        }

		void DismissPage ()
		{
			if (App. Current. Properties. ContainsKey ( App. LoggedInUsernameAppProperty ) 
		     && App. Current. Properties. ContainsKey ( App. LoggedInPasswordAppProperty ))

				CoreMethods. SwitchOutRootNavigation ( App. MainAppMasterDetailContainerName );

			else
				CoreMethods. SwitchOutRootNavigation ( App. LoginContainerName );
		}
    }
}
