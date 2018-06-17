using System;
using PropertyChanged;

namespace AutoskillTestRun. Models
{
	[AddINotifyPropertyChangedInterface]
    public class Contact
    {
        public Contact () {}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
    }
}
