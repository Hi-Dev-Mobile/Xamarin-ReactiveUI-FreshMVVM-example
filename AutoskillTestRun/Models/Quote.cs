using PropertyChanged;

namespace AutoskillTestRun. Models
{
	/// <summary>
    /// attribute needed to update models automatically
    /// </summary>
	[AddINotifyPropertyChangedInterface]
    public class Quote
    {
        public Quote (){}

		public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Total { get; set; }
    }
}
