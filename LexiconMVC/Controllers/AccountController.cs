using LexiconMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Controllers
{
	public class AccountController: Controller
	{
		private readonly UserManager<ApplicationUserModel> _userManager;

		public AccountController(UserManager<ApplicationUserModel> userManager) {
			_userManager = userManager;
		}


		public IActionResult Index()
		{
			return View();
		}
	}
}
