using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Models
{
	[Table("City")]
	public class CityModel
	{
		[DisplayName("City ID")]
		[Key]
		[Range(1, int.MaxValue, ErrorMessage = "ID must be larger than 0.")]
		public int CityId { get; set; }

		[DisplayName("Name")]
		[Required]
		[MinLength(3, ErrorMessage = "Please enter a name.")]
		[MaxLength(128, ErrorMessage = "The name can not be longer than 128 characters.")]
		public string Name { get; set; }

		[DisplayName("Population")]
		public int Population { get; set; }

		[DisplayName("Country")]
		[Required]
		[ForeignKey("CountryId")]
		public CountryModel Country { get; set; }
		public int CountryId { get; set; }

		public List<PersonModel> People { get; set; }
	}
}
