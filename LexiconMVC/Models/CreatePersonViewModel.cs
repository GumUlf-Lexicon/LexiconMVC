using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Models
{
	// CreatePersonViewModel
	// - Use to prevent overposting and to use data
	// annotations to validate inputs when creating
	// new person.
	public class CreatePersonViewModel
	{
		[DataType(DataType.Text)]
		[DisplayName("Name")]
		[Required(ErrorMessage = "You have to enter the person's name!")]
		[MinLength(3, ErrorMessage = "The name has to be at least three characters long!")]
		[MaxLength(128, ErrorMessage = "The name cannot be longer than 128 characters long!")]
		public string Name { get; set; }

		[DataType(DataType.PhoneNumber)]
		[DisplayName("Phone number")]
		[Required(ErrorMessage = "You have to enter the person's phone number!")]
		[MinLength(3, ErrorMessage = "The phone number has to have least three characters!")]
		[MaxLength(128, ErrorMessage = "The phone number cannot be longer than 128 characters!")]
		public string PhoneNumber { get; set; }

		[DataType(DataType.Text)]
		[DisplayName("City")]
		[Required(ErrorMessage ="You have to enter the person's city!")]
		[MinLength(3, ErrorMessage = "The city name has to have at least one character!")]
		[MaxLength(128, ErrorMessage = "The city name cannot have more than 128 characters!")]
		public string City { get; set; }
	}
}
