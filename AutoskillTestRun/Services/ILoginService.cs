using System;


namespace AutoskillTestRun. Services
{
	public interface ILoginService
    {
		IObservable<int> Login ( string username, string password );
    }
}
