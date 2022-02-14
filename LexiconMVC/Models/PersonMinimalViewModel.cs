using System.ComponentModel;
namespace LexiconMVC.Models
{
	public class PersonMinimalViewModel
	{
		[DisplayName("Person ID")]
		public int PersonId { get; set; }

		[DisplayName("Name")]
		public string Name { get; set; }

		[DisplayName("CityName")]
		public string CityName { get; set; }

		[DisplayName("CountryName")]
		public string CountryName { get; set; }

	}
}

