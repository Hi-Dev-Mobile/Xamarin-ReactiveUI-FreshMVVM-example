using System;
using FreshMvvm;
using ReactiveUI;
using PropertyChanged;
using AutoskillTestRun. Services;
using System. Linq;
using System. Reactive. Disposables;
using Xamarin. Forms;
using System. Threading. Tasks;
using AutoskillTestRun. Pages;
using System. ComponentModel;

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


		public ReactiveCommand LoginCommand
		{
			get => ReactiveCommand. Create ( () => Console. WriteLine ( "login???" ) );
		}

		public LoginPageModel ( ILoginService loginService )
		{
			this. loginService = loginService;

			this
				. WhenAnyValue (
					property1: x => x. Username,
					property2: x => x. Password,
					selector: CheckCredentialsValid )
				. ToProperty ( this, v => v. CanLogin, out _canLogin )
				. DisposeWith ( disposeBag );

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
	}
}
