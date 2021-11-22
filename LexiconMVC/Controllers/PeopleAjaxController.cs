using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LexiconMVC.Models;

namespace LexiconMVC.Controllers
{
	public class PeopleAjaxController: Controller
	{
		public IActionResult Index()
		{
			// If this is the first time running, persons are added to
			// the people register.
			if(!PeopleRegister.HasBeenPopulated)
			{
				PeopleRegister.HasBeenPopulated = new PeopleRegister().Populate();
			}

			return View();
		}

		// Get a list of persons in the people register
		[HttpGet]
		public IActionResult GetPersons()
		{
			PeopleRegister people = new PeopleRegister();
			List<Person> personList = people.GetPersons();

			return PartialView("_partialPersonList", personList);
		}


		// Get a specific person in the people register
		[HttpPost]
		public IActionResult GetPersonById(int personId)
		{
			PeopleRegister people = new PeopleRegister();
			Person foundPerson = people.GetPerson(personId);
			List<Person> personList = new List<Person>();

			if(!(foundPerson is null))
				personList.Add(foundPerson);

			return PartialView("_partialPersonList", personList);

		}


		// Remove a specific person from the register
		[HttpPost]
		public IActionResult RemovePersonById(int personId)
		{
			PeopleRegister people = new PeopleRegister();

			Person personToRemove = people.GetPerson(personId);

			if(!(personToRemove is null))
			{
				if(people.Remove(personToRemove))
				{
					// The person was removed
					return StatusCode(200);
				}
			}

			// The person was not removed, the person probably
			// was not in the register
			return StatusCode(404);
		}
	}


}
