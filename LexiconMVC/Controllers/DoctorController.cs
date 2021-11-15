using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Controllers
{
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
