﻿using System;

using Xamarin. Forms;
using Xamarin. Forms. Xaml;

using FreshMvvm;

using AutoskillTestRun. Pages;
using AutoskillTestRun. PageModels;
using AutoskillTestRun. Services;


//[assembly: XamlCompilation ( XamlCompilationOptions. Compile )]
namespace AutoskillTestRun
{
    public class App : Application
    {
        public App ()
        {
            FreshIOC. Container. Register<IDatabaseService, DatabaseService> ();
            FreshIOC. Container. Register<ILoginService, LoginService> ();

            var loginPage = FreshPageModelResolver. ResolvePageModel<LoginPageModel> ();
            var navigationContainer = new FreshNavigationContainer ( loginPage, "LoginPageArea" );
            navigationContainer. Title = "Login";
            MainPage = navigationContainer;

        }

        void LoadMain ()
        {

            var masterDetailsMultiple = new MasterDetailPage ();
            var mainMenuPage = FreshPageModelResolver. ResolvePageModel<MainMenuPageModel> ();
            mainMenuPage. Title = "Menu";

            var masterPageArea = new FreshNavigationContainer ( mainMenuPage, "MasterPageArea" );
            masterPageArea. Title = "Menu";
            masterPageArea. Icon = "menu.png";

            masterDetailsMultiple. Master = masterPageArea;

            var detailPageArea = new FreshTabbedNavigationContainer ( "DetailPageArea" ) { Title = "Home" };
            detailPageArea. AddTab<HomePageModel> ( title: "Contacts", icon: "contacts.png", data: null );
            detailPageArea. AddTab<QuoteListPageModel> ( title: "Quotes", icon: "document.png", data: null );

            masterDetailsMultiple. Detail = detailPageArea;

            MainPage = masterDetailsMultiple;
        }
    }
}