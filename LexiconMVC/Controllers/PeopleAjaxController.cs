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
			if(!PeopleRegister.HasBeenPopulated)
			{
				PeopleRegister.HasBeenPopulated = new PeopleRegister().Populate();
			}

			return View();
		}

		[HttpGet]
		public IActionResult GetPersons()
		{
			PeopleRegister people = new PeopleRegister();
			List<Person> personList = people.GetPersons();

			return PartialView("_partialPersonList", personList);
		}

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


		[HttpPost]
		public IActionResult RemovePersonById(int personId)
		{
			PeopleRegister people = new PeopleRegister();

			Person personToRemove = people.GetPerson(personId);

			if(!(personToRemove is null))
			{
				if(people.Remove(personToRemove))
				{
					return StatusCode(200, "OK");
				}
			}

			return StatusCode(404, "Person Not Found!");
		}
	}


}
