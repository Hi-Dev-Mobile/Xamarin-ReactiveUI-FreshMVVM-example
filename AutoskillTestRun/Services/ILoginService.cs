using System;
using System. Threading. Tasks;


namespace AutoskillTestRun. Services
{
	public interface ILoginService
    {
		Task<bool> Login ( string username, string password );
    }
}
