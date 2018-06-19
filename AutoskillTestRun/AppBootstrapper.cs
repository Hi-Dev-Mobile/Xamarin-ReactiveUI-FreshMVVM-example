using System;

using Xamarin. Forms;
using Xamarin. Forms. Xaml;

using FreshMvvm;

using AutoskillTestRun. Pages;
using AutoskillTestRun. PageModels;
using AutoskillTestRun. Services;


namespace AutoskillTestRun
{
    public class App : Application
    {
		public static string LoginContainerName = "LoginContainer";
		public static string MainAppMenuContainerName = "MainMenuContainer";
		public static string MainAppDetailContainerName = "MainAppContainer";
		public static string MainAppMasterDetailContainerName = "MainAppMasterDetailContainer";

        public App ()
        {
            FreshIOC. Container. Register<IDatabaseService, DatabaseService> ();
            FreshIOC. Container. Register<ILoginService, LoginService> ();

            var loginPage = FreshPageModelResolver. ResolvePageModel<LoginPageModel> ();
			var navigationContainer = new FreshNavigationContainer ( loginPage, LoginContainerName );
            navigationContainer. Title = "Login";
            MainPage = navigationContainer;

			LoadMain ();
        }


        void LoadMain ()
        {
            var mainMenuPage = FreshPageModelResolver. ResolvePageModel<MainMenuPageModel> ();
            mainMenuPage. Title = "Menu";

			var masterPageArea = new FreshNavigationContainer ( mainMenuPage, MainAppMenuContainerName );
            masterPageArea. Title = "Menu";
            masterPageArea. Icon = "menu.png";

			var detailPageArea = new FreshTabbedNavigationContainer ( MainAppDetailContainerName ) { Title = "Home" };
            detailPageArea. AddTab<HomePageModel> ( title: "Contacts", icon: "contacts.png", data: null );
            detailPageArea. AddTab<QuoteListPageModel> ( title: "Quotes", icon: "document.png", data: null );

			var masterDetailPageArea = new FreshMasterDetailNavigationContainer ( MainAppMasterDetailContainerName );
			masterDetailPageArea. Master = masterPageArea;
			masterDetailPageArea. Detail = detailPageArea;
        }
    }
}
