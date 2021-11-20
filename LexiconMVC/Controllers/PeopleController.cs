using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Controllers
{
	public class PeopleController: Controller
	{
		private static readonly PeopleViewModel pwm = new PeopleViewModel();
		private static bool isPeoplePopulated = false;

		public IActionResult Index()
		{
			if(!isPeoplePopulated)
			{
				_ = pwm.PopulatePeople();
				isPeoplePopulated = true;
			}

			return View(pwm);
		}

		public IActionResult RemovePerson(int personId)
		{
			int personIndex =	pwm.People.FindIndex(person => person.PersonId == personId);

			if(personIndex >= 0)
			{
				pwm.People.RemoveAt(personIndex);
			}

			return View("Index", pwm);
		}

		[HttpPost]
		public IActionResult CreatePerson(CreatePersonViewModel createPersonVM)
		{
			ViewBag.modelErrors = null;

			if(ModelState.IsValid)
			{
				pwm.People.Add(new Person(createPersonVM.Name, createPersonVM.PhoneNumber, createPersonVM.City));
				ModelState.Clear();
			}
			else
			{
				var modelErrors = new List<string>();
				foreach(var modelState in ModelState.Values)
				{
					foreach(var modelError in modelState.Errors)
					{
						modelErrors.Add(modelError.ErrorMessage);
					}
				}

				ViewBag.modelErrors = modelErrors;

			}
			return View("Index", pwm);
		}


		[HttpPost]
		public IActionResult FilterPersons(string filtersString)
		{
			if(string.IsNullOrWhiteSpace(filtersString))
			{
				pwm.SearchPhrase = null;
			}
			else
			{
				pwm.SearchPhrase = filtersString;
			}

			return View("Index", pwm);
		}
	}
}
