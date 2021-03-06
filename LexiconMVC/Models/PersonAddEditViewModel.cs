using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
	public class PersonAddEditViewModel
	{

		[DisplayName("Person ID")]
		[Range(1, int.MaxValue)]
		public int PersonId { get; set; }

		[DisplayName("Name")]
		[Required]
		[MinLength(3, ErrorMessage = "Please enter a name.")]
		[MaxLength(128, ErrorMessage = "The name can not be longer than 128 characters.")]
		public string Name { get; set; }

		[DisplayName("Phone number")]
		[Required]
		[MinLength(3, ErrorMessage = "Please enter a phone number")]
		[MaxLength(32, ErrorMessage = "The phone number can not be longer than 32 characters.")]
		[Phone]
		public string PhoneNumber { get; set; }

		[DisplayName("City")]
		[Required(ErrorMessage = "Please enter a city")]
		public int CityId { get; set; }
		public List<SelectListItem> Cities { get; set; }

		[DisplayName("Languages")]
		public int[] LanguageIds { get; set; }
		public List<SelectListItem> Languages { get; set; }

		public string SiteTitle { get; set; }

		public string SelectedAction { get; set; }

		public string SubmitButtonText { get; set; }

	}
}
