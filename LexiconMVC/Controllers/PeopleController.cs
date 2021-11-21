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

			if(ModelState.IsValid)
			{
				pwm.People.Add(new Person(createPersonVM.Name, createPersonVM.PhoneNumber, createPersonVM.City));
				ModelState.Clear();
				pwm.SearchPhrase = null;
			}

			return View("Index", pwm);
		}


		[HttpPost]
		public IActionResult FilterPersons(string searchPhrase)
		{
			if(string.IsNullOrWhiteSpace(searchPhrase))
			{
				pwm.SearchPhrase = null;
			}
			else
			{
				pwm.SearchPhrase = searchPhrase;
			}

			return View("Index", pwm);
		}
	}
}
