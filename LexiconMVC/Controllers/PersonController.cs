using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using LexiconMVC.Models;
using LexiconMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LexiconMVC.Controllers
{
	public class PersonController: Controller
	{

		private readonly LexiconDbContext _lexiconDb;

		public PersonController(LexiconDbContext lexiconDb)
		{
			_lexiconDb = lexiconDb;
		}

		public IActionResult Index()
		{
			ViewData["LanguageId"] = new SelectList(_lexiconDb.Languages, "LanguageId", "Name");
			return View();
		}

		// Get a list of persons in the people register
		[HttpGet]
		public IActionResult GetPersons()
		{
			List<PersonModel> people = _lexiconDb.People
				.Include(person => person.City)
				.Where(person => person.CityId == person.City.CityId)
				.Include(p => p.PersonLanguages)
				.ThenInclude(pl => pl.Language)
				.ToList();

			return PartialView("_partialPersonList", people);
		}


		// Get a specific person in the people register
		[HttpPost]
		public IActionResult GetPersonById(int personId)
		{
			List<PersonModel> persons =
				_lexiconDb.People
				.Include(person => person.City)
				.Where(person => person.PersonId == personId)
				.Where(person => person.CityId == person.City.CityId)
				.ToList();

			return PartialView("_partialPersonList", persons);
		}

		// Remove a specific person from the register
		[HttpPost]
		public IActionResult RemovePersonById(int personId)
		{
			PersonModel personToRemove =
				(from person in _lexiconDb.People.ToList()
				 where person.PersonId == personId
				 select person).FirstOrDefault();

			if(!(personToRemove is null))
			{
				_ = _lexiconDb.People.Remove(personToRemove);
				_lexiconDb.SaveChanges();
				// The person was removed
				return StatusCode(200);
			}

			// The person was not removed, the person probably
			// was not in the register
			return StatusCode(404);
		}

		[HttpPost]
		public IActionResult AddLanguageToPerson(int personId, int languageId)
		{
			PersonModel person = _lexiconDb.People
				.Where(person => person.PersonId == personId)
				.FirstOrDefault();

			LanguageModel language = _lexiconDb.Languages
				.Where(language => language.LanguageId == languageId)
				.FirstOrDefault();

			var persLang = _lexiconDb.PersonLanguages
				.Where(pl => pl.PersonId == personId && pl.LanguageId == languageId).Count();


			if(!(person is null) && !(language is null) && persLang == 0)
			{
				PersonLanguageModel personLanguage = new PersonLanguageModel
				{
					PersonId = personId,
					LanguageId = languageId
				};

				_lexiconDb.PersonLanguages.Add(personLanguage);
				_lexiconDb.SaveChanges();

				return StatusCode(200);
			}


			return StatusCode(404);

		}
	}


}
