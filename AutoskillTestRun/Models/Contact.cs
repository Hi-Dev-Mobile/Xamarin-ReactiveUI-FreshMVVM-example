using PropertyChanged;

namespace AutoskillTestRun. Models
{
	/// <summary>
    /// attribute needed to update models automatically
    /// </summary>
	[AddINotifyPropertyChangedInterface]
    public class Contact
    {
        public Contact () {}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
    }
}
