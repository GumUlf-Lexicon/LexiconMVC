using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
	public class PersonInfoViewModel
	{
		[DisplayName("Person ID")]
		public int PersonId { get; set; }

		[DisplayName("Name")]
		public string Name { get; set; }

		[DisplayName("Phone number")]
		[Phone]
		public string PhoneNumber { get; set; }

		[DisplayName("CityName")]
		public string CityName { get; set; }

		[DisplayName("CountryName")]
		public string CountryName { get; set; }


		[DisplayName("Languages")]
		public List<LanguageViewModel> Languages { get; set; }

	}
}
