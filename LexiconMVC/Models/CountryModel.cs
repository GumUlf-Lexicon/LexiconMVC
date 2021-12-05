using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Models
{
	[Table("Country")]
	public class CountryModel
	{
		[DisplayName("Country ID")]
		[Key]
		[Range(1, int.MaxValue, ErrorMessage = "ID must be larger than 0.")]
		public int CountryId { get; set; }

		[DisplayName("Name")]
		[Required]
		[MinLength(3, ErrorMessage = "Please enter a name.")]
		[MaxLength(128, ErrorMessage = "The name can not be longer than 128 characters.")]
		public string Name { get; set; }

		[DisplayName("Population")]
		public int Population { get; set; }

		public List<CityModel> Cities { get; set; }

	}
}
