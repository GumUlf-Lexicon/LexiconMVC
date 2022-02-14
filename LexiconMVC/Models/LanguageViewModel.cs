using System.ComponentModel;

namespace LexiconMVC.Models
{
	public class LanguageViewModel
	{
		[DisplayName("Language ID")]
		public int LanguageId { get; set; }

		[DisplayName("Name")]
		public string Name { get; set; }
	}
}
