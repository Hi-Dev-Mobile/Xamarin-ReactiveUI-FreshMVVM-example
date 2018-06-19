using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System. Reactive;
using System.Security.Authentication;
using System.Reactive.Disposables;


namespace AutoskillTestRun. Services
{
	public class LoginService: ILoginService
    {
		static public string NoUserError = "User not found";
		static public string IncorrectPasswordError = "Password Incorrect";


		Dictionary<string, string> userCredentials;

		private int loginAttempts = 0;

        public LoginService ()
        {
			userCredentials = new Dictionary<string, string> ();
			userCredentials. Add ( "Kat", "1" );
        }


		public IObservable<int> Login ( string username, string password )
		{
			var observable = Observable. Create<int> ( ( observer ) =>
			{
				loginAttempts += 1;

				observer. OnNext ( loginAttempts );

				if (userCredentials. ContainsKey ( username ))
					if (userCredentials [username] == password)
						observer. OnCompleted ();
					else
		    			observer. OnError ( new InvalidCredentialException ( IncorrectPasswordError ) );

				else
					observer. OnError ( new InvalidCredentialException ( NoUserError ) );

				return Disposable.Empty;
			} );
            
			return observable;
		}
    }
}
