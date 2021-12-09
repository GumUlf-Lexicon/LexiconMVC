using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace LexiconMVC.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class RegisterModel: PageModel
	{
		private readonly SignInManager<ApplicationUserModel> _signInManager;
		private readonly UserManager<ApplicationUserModel> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ILogger<RegisterModel> _logger;
		private readonly IEmailSender _emailSender;

		public RegisterModel(
			 UserManager<ApplicationUserModel> userManager,
			 SignInManager<ApplicationUserModel> signInManager,
			 RoleManager<IdentityRole> roleManager,
			 ILogger<RegisterModel> logger,
			 IEmailSender emailSender)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_logger = logger;
			_emailSender = emailSender;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public string ReturnUrl { get; set; }

		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		public class InputModel
		{

			[Required]
			[Display(Name = "User name")]
			[StringLength(128, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
			public string UserName { get; set; }

			[Required]
			[Display(Name = "First name")]
			[StringLength(128, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
			public string FirstName { get; set; }

			[Required]
			[Display(Name = "Last name")]
			[StringLength(128, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
			public string LastName { get; set; }

			[Display(Name = "Date of birth")]
			[DataType(DataType.Date)]
			public DateTime DateOfBirth { get; set; }

			[Required]
			[Display(Name = "Email")]
			[EmailAddress]
			public string Email { get; set; }

			[Required]
			[Display(Name = "Password")]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 12)]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			[Display(Name = "Confirm password")]
			[DataType(DataType.Password)]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }

		}

		public async Task OnGetAsync(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{

			returnUrl ??= Url.Content("~/");
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
			if(ModelState.IsValid)
			{
				var user = new ApplicationUserModel
				{
					UserName = Input.UserName,
					Email = Input.Email,
					FirstName = Input.FirstName,
					LastName = Input.LastName,
					DateOfBirth = Input.DateOfBirth
				};
				var result = await _userManager.CreateAsync(user, Input.Password);
				if(result.Succeeded)
				{
					// If this is the first time we run registration we create
					// the role "user". All users are added to this role
					const string userRole = "user";
					if(!await _roleManager.RoleExistsAsync(userRole))
					{
						await _roleManager.CreateAsync(new IdentityRole(userRole));
					}
					_ = await _userManager.AddToRoleAsync(user, userRole);
					_logger.LogInformation("User created a new account with password.");

					// If this is the first time we run registration, we create
					// the role "admin". Only the first registred user is added
					// this role.
					const string adminRole = "admin";
					if(!await _roleManager.RoleExistsAsync(adminRole))
					{
						await _roleManager.CreateAsync(new IdentityRole(adminRole));
						await _userManager.AddToRoleAsync(user, adminRole);
						_logger.LogInformation($"Admin role created and user {user.NormalizedUserName } was added as admin.");
					}



					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					var callbackUrl = Url.Page(
						 "/Account/ConfirmEmail",
						 pageHandler: null,
						 values: new { area = "Identity", userId = user.Id, code, returnUrl },
						 protocol: Request.Scheme);

					await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
						 $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

					if(_userManager.Options.SignIn.RequireConfirmedAccount)
					{
						return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl });
					}
					else
					{
						await _signInManager.SignInAsync(user, isPersistent: false);
						return LocalRedirect(returnUrl);
					}
				}
				foreach(var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}
	}
}
