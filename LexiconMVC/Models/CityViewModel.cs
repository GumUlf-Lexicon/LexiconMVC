using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
	public class CityViewModel
	{
		[DisplayName("City ID")]
		[Range(1, int.MaxValue, ErrorMessage = "ID must be larger than 0.")]
		public int CityId { get; set; }

		[DisplayName("Name")]
		[Required]
		[MinLength(3, ErrorMessage = "Please enter a name.")]
		[MaxLength(128, ErrorMessage = "The name can not be longer than 128 characters.")]
		public string Name { get; set; }

		[DisplayName("Population")]
		[Range(0, int.MaxValue, ErrorMessage = "Population must be at least 0.")]
		public int Population { get; set; }

		[DisplayName("CountryId")]
		[Required(ErrorMessage = "City must be in a country.")]
		public int CountryId { get; set; }

		[DisplayName("Country Name")]
		public string CountryName { get; set; }
	}
}
