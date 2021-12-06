using System.ComponentModel.DataAnnotations.Schema;


namespace LexiconMVC.Models
{

	[Table("PersonLanguage")]
	public class PersonLanguageModel
	{
		public int PersonId { get; set; }
		public PersonModel Person { get; set; }


		public int LanguageId { get; set; }
		public LanguageModel Language { get; set; }

	}
}
