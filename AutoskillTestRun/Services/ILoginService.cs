using System;

namespace AutoskillTestRun. Services
{
	/// <summary>
    /// If you're only having one implementation of LoginSevice
    /// the interface is unnecessary, but wanted to give an example
    /// of best practices for more complicated situations.
    /// </summary>
	public interface ILoginService
    {
		IObservable<int> Login ( string username, string password );
    }
}
