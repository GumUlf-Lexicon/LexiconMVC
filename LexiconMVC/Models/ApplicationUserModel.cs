using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
	public class ApplicationUserModel: IdentityUser
	{
	
		[DisplayName("First name")]
		[Required]
		public string FirstName { get; set; }

		[DisplayName("Last name")]
		[Required]
		public string LastName { get; set; }

		[DisplayName("Date of birth")]
		[Required]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }
	}
}
