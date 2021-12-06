using Microsoft.AspNetCore.Identity;
using System;

namespace LexiconMVC.Models
{
	public class ApplicationUserModel: IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
