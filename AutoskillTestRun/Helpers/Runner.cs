using System;
using System. Collections. Generic;
using System. Reactive. Disposables;
using System. Reactive. Linq;
using System. Reactive. Subjects;
using System. Threading. Tasks;

namespace AutoskillTestRun
{
    public class Runner
    {
		public static Runner<T> Create<T> (Func<T> func) 
		{
			return new Runner<T> ( func );
		}

        public Runner ()
        {
        }
    }

	public class Runner<T> : IObservable<T>
	{
		private readonly Func<T> func;
		private readonly List<IObserver<T>> observers = new List<IObserver<T>>();
		private T currentValue;
		private bool currentValueIsValid = false;
		private Subject<Exception> thrownExceptions { get; set; }
		public IObservable<Exception> ThrownExceptions { get; set; }

		internal Runner(Func<T> func)
		{
			this. func = func;
			thrownExceptions = new Subject<Exception> ();
			ThrownExceptions = thrownExceptions. AsObservable ();
		}

        public void Execute ()
		{
			try {
				Task. Run ( func ). ContinueWith ( task =>
				{
					var a = task. Result;
					currentValue = a;
					currentValueIsValid = true;

					foreach (var observer in observers) {
						try {
							observer. OnNext ( a );
						}
						catch (Exception) {
							RemoveSubscriber ( observer );
						}
					}
				} );
			}
			catch (Exception e) {
				thrownExceptions. OnNext ( e );
			}
		}

		public IDisposable Subscribe ( IObserver<T> observer )
		{
			observers. Add ( observer );
			var disposer = new Disposer<T> ( this, observer );
			if (currentValueIsValid)
				observer. OnNext ( currentValue );

			return Disposable. Create ( disposer. Dispose );
		}

		public void RemoveSubscriber ( IObserver<T> observer )
		{
			try {
				observers. Remove ( observer );
			}
			catch {}
		}
	}
}
