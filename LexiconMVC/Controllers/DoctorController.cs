using LexiconMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LexiconMVC.Controllers
{
	[AllowAnonymous]
	public class DoctorController: Controller
	{

		public IActionResult FeverCheck()
		{
			// No temp has been checked yet
			ViewBag.feverMessage = null;

			return View();
		}

		[HttpPost]
		public IActionResult FeverCheck(string bodyTemperature)
		{
			// Passing the result from fever checker
			ViewBag.feverMessage = FeverUtility.CheckForFever(bodyTemperature);

			return View();
		}
	}
}
