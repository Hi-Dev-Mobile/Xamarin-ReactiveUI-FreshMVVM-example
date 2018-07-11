using System;

namespace AutoskillTestRun
{
    public class Disposer<T>
    {
		private readonly Runner<T> runner;
		private readonly IObserver<T> observer;
        

        public Disposer (Runner<T> runner, IObserver<T> observer)
        {
			this. runner = runner;
			this. observer = observer;
        }

        public void Dispose()
		{
			runner. RemoveSubscriber ( observer );
		}
    }
}
