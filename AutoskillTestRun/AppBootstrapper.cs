using Xamarin. Forms;
using FreshMvvm;

using AutoskillTestRun. PageModels;
using AutoskillTestRun. Services;

namespace AutoskillTestRun
{   
	public partial class App : Application
    {
		public static string LoginContainerName               = "LoginContainer";
		public static string OnboardingContainerName          = "OnboardingContainer";
		public static string MainAppMenuContainerName         = "MainMenuContainer";
		public static string MainAppDetailContainerName       = "MainAppContainer";
		public static string MainAppMasterDetailContainerName = "MainAppMasterDetailContainer";

		public static string IsFirstTimeAppProperty        = "IsFirstTime";
		public static string IsVersionFirstTimeAppProperty = "IsVersionFirstTime";
		public static string LoggedInUsernameAppProperty   = "LoggedInUsername";
		public static string LoggedInPasswordAppProperty   = "LoggedInPassword";

		private static FreshMasterDetailNavigationContainer mainMasterDetail;

        public App ()
        {
			// connects to the App.xaml for connnection to resource dictionary
			InitializeComponent ();

            // register services so pageModels can access them
            FreshIOC. Container. Register<IDatabaseService, DatabaseService> ();
            FreshIOC. Container. Register<ILoginService, LoginService> ();
   

			if (!Properties.ContainsKey (IsFirstTimeAppProperty)) {
				Properties [IsFirstTimeAppProperty] = false;
				SavePropertiesAsync ();

				MainPage = LoadOnboarding ();
				LoadLogin ();
				LoadMain ();
			}
            else if (Properties. ContainsKey ( LoggedInUsernameAppProperty ) 
		          && Properties. ContainsKey ( LoggedInPasswordAppProperty )) {
				
				MainPage = LoadMain ();
				LoadLogin ();
				LoadOnboarding ();
			}
			else {
				MainPage = LoadLogin ();
				LoadMain ();
				LoadOnboarding ();
			}
        }
  

		Page LoadOnboarding ()
		{
			var onboardingPage = FreshPageModelResolver. ResolvePageModel<OnboardingPageModel> ();
			return onboardingPage;
		}


		Page LoadLogin () 
		{
			var loginPage = FreshPageModelResolver. ResolvePageModel<LoginPageModel> ();
            var navigationContainer = new FreshNavigationContainer ( loginPage, LoginContainerName );
            navigationContainer. Title = "Login";
            
			return navigationContainer;
		}


        Page LoadMain ()
        {
			// init main page using resolver
            var mainMenuPage = FreshPageModelResolver. ResolvePageModel<MainMenuPageModel> ();
            mainMenuPage. Title = "Menu";

			var masterPageArea = new FreshNavigationContainer ( mainMenuPage, MainAppMenuContainerName );
            masterPageArea. Title = "Menu";
            masterPageArea. Icon = "menu.png";

            // this is for the tab bar on the bottom
			var detailPageArea = new FreshTabbedNavigationContainer ( MainAppDetailContainerName ) { Title = "Home" };
			// data allows us to send an object to the Init() of the pageModel. not needed here, but useful.
            detailPageArea. AddTab<HomePageModel> ( title: "Contacts", icon: "contacts.png", data: null );
            detailPageArea. AddTab<QuoteListPageModel> ( title: "Quotes", icon: "document.png", data: null );

            // this is so we can have the hamburger menu
			var masterDetailPageArea = new FreshMasterDetailNavigationContainer ( MainAppMasterDetailContainerName );
			masterDetailPageArea. Master = masterPageArea;
			masterDetailPageArea. Detail = detailPageArea;
            
			App. mainMasterDetail = masterDetailPageArea;

			return masterDetailPageArea;
        }


        public static void ToggleMainMenu (bool isPresented)
		{
			mainMasterDetail. IsPresented = isPresented;
		}
    }
}
