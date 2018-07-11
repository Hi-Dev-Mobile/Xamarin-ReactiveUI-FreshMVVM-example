using System;
using System. Collections. Generic;
using System. Collections. ObjectModel;
using System. Collections. Specialized;
using System. Linq;

using AutoskillTestRun. PageModels;


namespace AutoskillTestRun
{   
	public static class ExceptionExtensions
	{
		public static void DisplayAlert(this Exception exception, BasePageModel pageModel)
		{
			Console. WriteLine ( "EXCEPTION: " + exception. GetType () + ", " + exception. Message );

			if (pageModel == null) return;
            
            var exceptionSubtype = exception
                . GetType ()
                . ToString ()
                . Split ( '.' )
                . ToList ()
                . Last ();

            pageModel. CoreMethods. DisplayAlert ( "Error", exception. Message + "\n\n" + exceptionSubtype, "Close" );
		}
	}


	public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private bool _suppressNotification = false;
  

		protected override void OnCollectionChanged ( NotifyCollectionChangedEventArgs e )
        {
            if (!_suppressNotification)
                base. OnCollectionChanged ( e );
        }

        /// <summary>
        /// Adds a list to an ObservableCollection
		/// Not used in this project, but is extremly handy
        /// </summary>
        public void AddRange ( IEnumerable<T> list )
        {
            if (list == null)
                throw new ArgumentNullException ( "list" );

            _suppressNotification = true;

            foreach (T item in list) 
                Add ( item );
            
            _suppressNotification = false;
            OnCollectionChanged ( new NotifyCollectionChangedEventArgs ( NotifyCollectionChangedAction. Reset ) );
        }
    }
}
