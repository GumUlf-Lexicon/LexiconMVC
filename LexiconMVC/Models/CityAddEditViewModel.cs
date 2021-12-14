using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
	public class CityAddEditViewModel
	{
		[DisplayName("City ID")]
		[Range(0, int.MaxValue)]
		public int CityId { get; set; }

		[DisplayName("Name")]
		[Required]
		[MinLength(3, ErrorMessage = "Please enter a name.")]
		[MaxLength(128, ErrorMessage = "The name can not be longer than 128 characters.")]
		public string Name { get; set; }

		[DisplayName("Population")]
		[Required]
		[Range(0, int.MaxValue)]
		public int Population { get; set; }

		[DisplayName("Country")]
		[Required(ErrorMessage = "Please enter a country")]
		public int CountryId { get; set; }
		public List<SelectListItem> Countries { get; set; }

		public string SiteTitle { get; set; }

		public string SelectedAction { get; set; }

		public string SubmitButtonText { get; set; }
	}
}
