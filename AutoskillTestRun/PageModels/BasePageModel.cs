using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Runtime. CompilerServices;

using FreshMvvm;
using ReactiveUI;
using System. Threading. Tasks;
using Xamarin. Forms;


namespace AutoskillTestRun. PageModels
{
    public class BasePageModel:
        FreshBasePageModel,
        IHandleObservableErrors,
        IReactiveObject,
        IReactiveNotifyPropertyChanged<IReactiveObject>
    {
        private string _pageTitle;
        public string PageTitle
        {
            get => _pageTitle;
            set => _pageTitle = value;
        }

        readonly FreshMvvmReactiveObject reactiveObject = new FreshMvvmReactiveObject ();


        ////////////////
        /// Interfaces 
        ////////////////

        /// <summary>
        /// IHandleObservableErrors
        /// </summary>
        public IObservable<Exception> ThrownExceptions => reactiveObject. ThrownExceptions;



        /// <summary>
        /// IReactiveObject
        /// </summary>
        public event System. ComponentModel. PropertyChangingEventHandler PropertyChanging
        {
            //add => reactiveObject. PropertyChanging += value;
            //         remove => reactiveObject. PropertyChanging -= value;
            add
            {
                //throw new NotImplementedException ();
                reactiveObject. PropertyChanging += value;
            }

            remove
            {
                //throw new NotImplementedException ();
                reactiveObject. PropertyChanging -= value;
            }
        }

        event System. ComponentModel. PropertyChangingEventHandler INotifyPropertyChanging.PropertyChanging
        {
            add
            {
                throw new NotImplementedException ();
            }

            remove
            {
                throw new NotImplementedException ();
            }
        }

        public void RaisePropertyChanging ( System. ComponentModel. PropertyChangingEventArgs args )
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
		public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing => reactiveObject. Changing;
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => reactiveObject. Changed;


        public bool SetProperty<T> ( ref T storage, T value, [CallerMemberName] string propertyName = null )
        {
            var original = storage;
            this. RaiseAndSetIfChanged ( ref storage, value, propertyName );
            return !EqualityComparer<T>. Default. Equals ( original, value );
        }


        public IDisposable SuppressChangeNotifications ()
        {
            var suppressor = reactiveObject. SuppressChangeNotifications ();
            return new DisposableAction ( () => suppressor. Dispose () );
        }

        //public void RaisePropertyChanging (System.ComponentModel.PropertyChangingEventArgs args)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
