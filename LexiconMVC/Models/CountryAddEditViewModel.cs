using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
	public class CountryAddEditViewModel
	{
		[DisplayName("Country ID")]
		[Range(0, int.MaxValue)]
		public int CountryId { get; set; }

		[DisplayName("Name")]
		[Required]
		[MinLength(3, ErrorMessage = "Please enter a name.")]
		[MaxLength(128, ErrorMessage = "The name can not be longer than 128 characters.")]
		public string Name { get; set; }

		[DisplayName("Population")]
		[Required]
		[Range(0, int.MaxValue)]
		public int Population { get; set; }

		public string SiteTitle { get; set; }

		public string SelectedAction { get; set; }

		public string SubmitButtonText { get; set; }
	}
}
