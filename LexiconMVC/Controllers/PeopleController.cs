using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LexiconMVC.Models;
using LexiconMVC.Data;

namespace LexiconMVC.Controllers
{
	public class PeopleController: Controller
	{

		private readonly PeopleDbContext _peopleDb;

		public PeopleController(PeopleDbContext peopleDb)
		{
			_peopleDb = peopleDb;
		}

		public IActionResult Index()
		{
			return View();
		}

		// Get a list of persons in the people register
		[HttpGet]
		public IActionResult GetPersons()
		{
			List<PersonModel> people = _peopleDb.People.ToList();
			return PartialView("_partialPersonList", people);
		}


		// Get a specific person in the people register
		[HttpPost]
		public IActionResult GetPersonById(int personId)
		{
			List<PersonModel> persons =
				(from person in _peopleDb.People.ToList()
				 where person.PersonId == personId
				 select person)
				 .ToList();

			return PartialView("_partialPersonList", persons);
		}

		// Remove a specific person from the register
		[HttpPost]
		public IActionResult RemovePersonById(int personId)
		{
			PersonModel personToRemove =
				(from person in _peopleDb.People.ToList()
				 where person.PersonId == personId
				 select person).FirstOrDefault();

			if(!(personToRemove is null))
			{
				_peopleDb.People.Remove(personToRemove);
				_peopleDb.SaveChanges();
				// The person was removed
				return StatusCode(200);
			}

			// The person was not removed, the person probably
			// was not in the register
			return StatusCode(404);
		}
	}


}
