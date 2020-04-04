using System. Reactive;
using FreshMvvm;
using ReactiveUI;

namespace AutoskillTestRun. PageModels
{
	public class MainMenuPageModel: FreshBasePageModel
    {
		public ReactiveCommand<Unit, Unit> AboutCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> LogoutCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> OnboardingCommand { get; private set; }
        

		public MainMenuPageModel () 
		{
			AboutCommand = ReactiveCommand. CreateFromTask ( async () => await CoreMethods. PushPageModel<AboutPageModel> ( null, modal: true ) );
			LogoutCommand = ReactiveCommand. Create ( LogoutUser );
			OnboardingCommand = ReactiveCommand. Create ( DisplayOnboarding );
        }


        void LogoutUser () 
        {
			App. Current. Properties. Remove ( App. LoggedInUsernameAppProperty );
			App. Current. Properties. Remove ( App. LoggedInPasswordAppProperty );
            // make sure changes get saved immediately
			App. Current. SavePropertiesAsync ();
			CoreMethods. SwitchOutRootNavigation ( App. LoginContainerName );
		}


        void DisplayOnboarding ()
		{
			App. ToggleMainMenu ( isPresented: false );
			App. Current. MainPage = FreshPageModelResolver. ResolvePageModel<OnboardingPageModel> ();
		}
    }
}
