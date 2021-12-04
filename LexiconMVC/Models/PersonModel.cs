using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace LexiconMVC.Models
{
	public class PersonModel
	{
		[DisplayName("Person ID")]
		[Key]
		[Range(1, int.MaxValue, ErrorMessage = "ID must be larger than 0.")]
		public int PersonId { get; set; }

		[DisplayName("Name")]
		[Required]
		[MinLength(3, ErrorMessage = "Please enter a name.")]
		[MaxLength(128, ErrorMessage = "The name can not be longer than 128 characters.")]
		public string Name { get; set; }

		[DisplayName("Phone number")]
		[Required]
		[MinLength(3, ErrorMessage ="Please enter a phone number")]
		[MaxLength(32, ErrorMessage = "The phone number is longer than 32 characters.")]
		[Phone]
		public string PhoneNumber { get; set; }

		[DisplayName("City")]
		[Required]
		[MinLength(1,ErrorMessage ="There has to be a city name.")]
		[MaxLength(128,ErrorMessage ="The cityname can not be longer than 128 characters.")]
		public string City { get; set; }
	}
}