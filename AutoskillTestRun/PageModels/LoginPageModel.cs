using System;
using System. Reactive. Disposables;

using PropertyChanged;
using FreshMvvm;
using ReactiveUI;

using AutoskillTestRun. Services;


namespace AutoskillTestRun. PageModels
{
	[AddINotifyPropertyChangedInterface]
	public class LoginPageModel : BasePageModel
	{

		ILoginService loginService;
		CompositeDisposable disposeBag = new CompositeDisposable ();

		string _username;
		public string Username { get => _username; set => this. RaiseAndSetIfChanged ( ref _username, value ); }

		string _password;
		public string Password { get => _password; set => this. RaiseAndSetIfChanged ( ref _password, value ); }

		ObservableAsPropertyHelper<bool> _canLogin;
		public bool CanLogin { get =>  _canLogin?.Value ?? false; }

		public ReactiveCommand LoginCommand { get; private set; }


		public LoginPageModel ( ILoginService loginService )
		{
			this. loginService = loginService;


			this
				. WhenAnyValue (
					property1: pm => pm. Username,
					property2: pm => pm. Password,
					selector: CheckCredentialsValid )
				. ToProperty ( this, pm => pm. CanLogin, out _canLogin )
				. DisposeWith ( disposeBag );
                
            
			LoginCommand = ReactiveCommand.Create (AttemptLogin);

            
			//// Runner Test /////
			var runner = Runner. Create<bool> ( () => true );
			var obs = runner
				. Subscribe ( ( value ) => Console. WriteLine ( "runner value: " + value ) )
				. DisposeWith ( disposeBag );
			runner. Execute ();
        }


        bool CheckCredentialsValid ( string username, string password)
		{
			return !string. IsNullOrEmpty ( username ) && !string. IsNullOrEmpty ( password );
		}


        void AttemptLogin () 
		{
			loginService
				. Login ( Username, Password )
				. Subscribe ( onNext: HandleLoginAttempt, 
				             onError: HandleLoginError, 
				             onCompleted: HandleLoginCompleted )
				. DisposeWith ( disposeBag );
        }


        void HandleLoginAttempt (int attemps) 
		{
			Console. WriteLine ( "login attempt: " + attemps );
		}


		void HandleLoginError(Exception error)
		{
			if (error. Message == LoginService. NoUserError)
				CoreMethods. DisplayAlert ( "Login Error", LoginService. NoUserError, "Close" );

			else if (error. Message == LoginService. IncorrectPasswordError)
				CoreMethods. DisplayAlert ( "Login Error", LoginService. IncorrectPasswordError, "Close" );

			else
                CoreMethods. DisplayAlert ( "Login Error", "Unknown error, please try again later.", "Close" );
		}

        void HandleLoginCompleted ()
		{
			CoreMethods. SwitchOutRootNavigation ( App. MainAppMasterDetailContainerName );
		}
	}
}
