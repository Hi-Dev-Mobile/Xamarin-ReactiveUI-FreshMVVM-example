using System;
using System. ComponentModel;
using System. Collections. Generic;
using System. Runtime. CompilerServices;

using FreshMvvm;
using ReactiveUI;

namespace AutoskillTestRun. PageModels
{
	public class BasePageModel: FreshBasePageModel, IHandleObservableErrors, IReactiveObject, IReactiveNotifyPropertyChanged<IReactiveObject>
    {
		readonly FreshMvvmReactiveObject reactiveObject = new FreshMvvmReactiveObject ();
  
        /// <summary>
        /// IHandleObservableErrors
        /// </summary>
		public IObservable<Exception> ThrownExceptions => reactiveObject.ThrownExceptions;
        

        /// <summary>
        /// IReactiveObject
        /// </summary>
		public event ReactiveUI. PropertyChangingEventHandler PropertyChanging {
			add => reactiveObject. PropertyChanging += value;
            remove => reactiveObject. PropertyChanging -= value;
		}
        

        public void RaisePropertyChanging ( ReactiveUI. PropertyChangingEventArgs args )
        {
			reactiveObject. RaisePropertyChanged ( propertyName: args. PropertyName );
            
        }
        

        public void RaisePropertyChanged ( PropertyChangedEventArgs args )
        {
			reactiveObject. RaisePropertyChanged ( propertyName: args. PropertyName );
			base. RaisePropertyChanged ( args. PropertyName );
        }
        

        /// <summary>
        /// IReactiveNotifyPropertyChanged
        /// </summary>
		public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing => reactiveObject.Changing;
		public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => reactiveObject.Changed;


		public bool SetProperty<T> ( ref T storage, T value, [CallerMemberName] string propertyName = null )
		{
			var original = storage;
			this. RaiseAndSetIfChanged ( ref storage, value, propertyName );
			return !EqualityComparer<T>. Default. Equals ( original, value );
		}


        public IDisposable SuppressChangeNotifications ()
        {
            var suppressor = reactiveObject. SuppressChangeNotifications ();
            return new DisposableAction ( () => suppressor.Dispose());
        }

    }
}
