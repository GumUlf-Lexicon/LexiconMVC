using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconMVC.Models
{
	[Table("Language")]
	public class LanguageModel
	{
		[DisplayName("Language ID")]
		[Key]
		[Range(1, int.MaxValue, ErrorMessage = "ID must be larger than 0.")]
		public int LanguageId { get; set; }

		[DisplayName("Name")]
		[Required]
		[MinLength(3, ErrorMessage = "Please enter a name.")]
		[MaxLength(128, ErrorMessage = "The name can not be longer than 128 characters.")]
		public string Name { get; set; }

		public List<PersonLanguageModel> PersonLanguages { get; set; }


	}
}

