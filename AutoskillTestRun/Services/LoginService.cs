using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AutoskillTestRun. Services
{
	public class LoginService: ILoginService
    {
		Dictionary<string, string> userCredentials;


        public LoginService ()
        {
			userCredentials = new Dictionary<string, string> ();
			userCredentials. Add ( "K", "1" );
        }

		public async Task<bool> Login (string username, string password)
		{
			if (userCredentials. ContainsKey ( username ))
				return userCredentials [username] == password;

			return false;
		}
    }
}
