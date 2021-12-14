using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
	public class LanguageAddEditViewModel
	{
		[DisplayName("Language ID")]
		[Range(0, int.MaxValue)]
		public int LanguageId { get; set; }

		[DisplayName("Name")]
		[Required]
		[MinLength(3, ErrorMessage = "Please enter a name.")]
		[MaxLength(128, ErrorMessage = "The name can not be longer than 128 characters.")]
		public string Name { get; set; }

		public string SiteTitle { get; set; }

		public string SelectedAction { get; set; }

		public string SubmitButtonText { get; set; }
	}
}
