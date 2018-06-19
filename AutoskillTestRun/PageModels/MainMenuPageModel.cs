using System;

using Xamarin.Forms;
using FreshMvvm;
using ReactiveUI;

namespace AutoskillTestRun. PageModels
{
	public class MainMenuPageModel: FreshBasePageModel
    {
		public ReactiveCommand AboutCommand { get; private set; }
		public ReactiveCommand LogoutCommand { get; private set; }
		public ReactiveCommand OnboardingCommand { get; private set; }
        

		public MainMenuPageModel () 
		{
			AboutCommand = ReactiveCommand. Create ( async () => await CoreMethods. PushPageModel<AboutPageModel> ( null, modal: true ) );
			LogoutCommand = ReactiveCommand. Create ( LogoutUser );
			OnboardingCommand = ReactiveCommand. Create ( DisplayOnboarding );

        }


        void LogoutUser () 
        {
			App. Current. Properties. Remove ( App. LoggedInUsernameAppProperty );
			App. Current. Properties. Remove ( App. LoggedInPasswordAppProperty );
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
