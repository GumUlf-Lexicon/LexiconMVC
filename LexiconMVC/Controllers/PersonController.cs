using LexiconMVC.Data;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LexiconMVC.Controllers
{
	[AllowAnonymous]
	//[Authorize(Roles = "admin, user")]
	public class PersonController: Controller
	{

		private readonly LexiconDbContext _lexiconDb;

		public PersonController(LexiconDbContext lexiconDb)
		{
			_lexiconDb = lexiconDb;
		}

		public IActionResult Index()
		{
			return View();
		}

		// Get a list of persons in the people register
		[HttpGet]
		public IActionResult GetPersons()
		{
			List<PersonMinimalViewModel> people = _lexiconDb.People
				.Include(person => person.City)
				.ThenInclude(c => c.Country)
				.Select(p => new PersonMinimalViewModel
				{
					PersonId = p.PersonId,
					Name = p.Name,
					CityName = p.City.Name,
					CountryName = p.City.Country.Name
				})
				.ToList();

			return Json(people);

		}


		// Get a specific person in the people register
		[HttpPost]
		public IActionResult PostGetPersonById([FromBody] int personId)
		{
			PersonInfoViewModel person =
				_lexiconDb.People
				.Include(person => person.City)
				.Where(person => person.PersonId == personId)
				.Include(person => person.City.Country)
				.Select(p => new PersonInfoViewModel
				{
					PersonId = p.PersonId,
					Name = p.Name,
					PhoneNumber = p.PhoneNumber,
					CityName = p.City.Name,
					CountryName = p.City.Country.Name,
				})
				.FirstOrDefault();

			if(person is null)
			{
				return StatusCode(StatusCodes.Status404NotFound, "Person not found");
			}

			person.Languages = _lexiconDb.PersonLanguages
					.Include(pl => pl.Language)
					.Where(pl => pl.LanguageId == pl.Language.LanguageId && pl.PersonId == personId)
					.Select(pl => new LanguageViewModel
					{
						LanguageId = pl.LanguageId,
						Name = pl.Language.Name
					})
					.ToList();

			return Json(person);
		}

		// Remove a specific person from the register
		[HttpPost]
		[Authorize(Roles = "admin")]
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

		[HttpGet]
		public IActionResult AddPerson()
		{
			PersonAddEditViewModel personViewModel = new PersonAddEditViewModel()
			{
				PersonId = 0,
				Name = "",
				PhoneNumber = "",
				SelectedLanguageIds = new List<int>(),
				Languages = GetLanguages(),
				CityId = 0,
				Cities = GetCities(),
			};

			return Json(personViewModel);
		}

		[HttpPost]
		public IActionResult AddPerson([FromBody]PersonAddEditViewModel newPerson)
		{
			if(!ModelState.IsValid)
			{
				return StatusCode(StatusCodes.Status422UnprocessableEntity, "Person object not valid");
			}

			PersonModel personToAdd = new PersonModel
			{
				Name = newPerson.Name,
				PhoneNumber = newPerson.PhoneNumber,
				CityId = newPerson.CityId
			};
			_lexiconDb.People.Add(personToAdd);
			_lexiconDb.SaveChanges();


			foreach(int langId in newPerson.SelectedLanguageIds)
			{
				if(_lexiconDb.Languages.Where(language => language.LanguageId == langId).Count() == 1)
				{
					PersonLanguageModel personLanguage = new PersonLanguageModel
					{
						PersonId = personToAdd.PersonId,
						LanguageId = langId
					};
					_lexiconDb.PersonLanguages.Add(personLanguage);
				}
			}
			_lexiconDb.SaveChanges();

			return StatusCode(StatusCodes.Status201Created, "Person added!");
		}


		[HttpGet]
		public IActionResult EditPerson(int personId)
		{
			PersonModel personToEdit = _lexiconDb.People
				.Where(person => person.PersonId == personId)
				.FirstOrDefault();

			if(personToEdit is null)
			{
				return StatusCode(StatusCodes.Status404NotFound, "Person does not exist!");
			}

			PersonAddEditViewModel personViewModel = new PersonAddEditViewModel()
			{
				// Person info
				PersonId = personId,
				Name = personToEdit.Name,
				PhoneNumber = personToEdit.PhoneNumber,
				CityId = personToEdit.CityId,

				SelectedLanguageIds = _lexiconDb.PersonLanguages
				.Include(pl => pl.Language)
				.Where(pl => pl.LanguageId == pl.Language.LanguageId && pl.PersonId == personId)
				.Select(pl => pl.LanguageId)
				.ToList(),

				// Available cities and languages
				Cities = GetCities(),
				Languages = GetLanguages(),

			};

			return StatusCode(StatusCodes.Status200OK, "Person updated!");
		}


		[HttpPost]
		public IActionResult EditPerson(PersonAddEditViewModel updatedPerson)
		{

			if(!ModelState.IsValid)
			{
				return RedirectToAction("AddEditPerson", updatedPerson.PersonId);
			}

			// Get person model to be able to edit the person
			PersonModel personToEdit = _lexiconDb.People
				.Where(person => person.PersonId == updatedPerson.PersonId)
				.FirstOrDefault();


			// The person does not exist, go back to first page
			if(personToEdit is null)
			{
				ViewData["Languages"] = new SelectList(_lexiconDb.Languages, "LanguageId", "Name");
				ViewData["UserMessages"] = "Person does not exist";

				return View("Index");
			}


			// If the name has changed, update it
			if(!updatedPerson.Name.Equals(personToEdit.Name))
				personToEdit.Name = updatedPerson.Name;

			// If the phone number has changed, update it
			if(!updatedPerson.PhoneNumber.Equals(personToEdit.PhoneNumber))
				personToEdit.PhoneNumber = updatedPerson.PhoneNumber;

			// If the city hase changed, update it if the new city is valid
			if(updatedPerson.CityId != personToEdit.CityId
				&& _lexiconDb.Cities.Where(city => city.CityId == updatedPerson.CityId).Count() == 1)
			{
				personToEdit.CityId = updatedPerson.CityId;
			}

			// Get a list of the languages the person speaks, to be able to
			// compare it to the updated list to know what to add add remove
			List<int> personLanguages =
				_lexiconDb.PersonLanguages
				.Include(pl => pl.Language)
				.Where(pl => pl.LanguageId == pl.Language.LanguageId && pl.PersonId == updatedPerson.PersonId)
				.Select(pl => pl.LanguageId)
				.ToList();

			// Find out what languages to and and to remove
			List<int> languagesToAdd = updatedPerson.SelectedLanguageIds.Except(personLanguages).ToList();
			List<int> languagesToRemove = personLanguages.Except(updatedPerson.SelectedLanguageIds).ToList();

			// Add new languages to the person, if the language is valid
			foreach(int langId in languagesToAdd)
			{
				if(_lexiconDb.Languages.Where(language => language.LanguageId == langId).Count() == 1)
				{
					PersonLanguageModel personLanguage = new PersonLanguageModel
					{
						PersonId = updatedPerson.PersonId,
						LanguageId = langId
					};
					_lexiconDb.PersonLanguages.Add(personLanguage);
				}
			}

			// Remove old languages from the person
			foreach(int langId in languagesToRemove)
			{
				PersonLanguageModel personLanguage = new PersonLanguageModel
				{
					PersonId = updatedPerson.PersonId,
					LanguageId = langId
				};
				_lexiconDb.PersonLanguages.Remove(personLanguage);
			}

			// Save the updated person information to the database
			_lexiconDb.SaveChanges();

			ViewData["Languages"] = new SelectList(_lexiconDb.Languages, "LanguageId", "Name");
			ViewData["UserMessages"] = "Person updated";

			return View("Index");
		}


		private List<LanguageViewModel> GetLanguages()
		{
			return _lexiconDb.Languages
					.Select(l => new LanguageViewModel
					{
						Name = l.Name,
						LanguageId = l.LanguageId
					}).ToList();
		}

		private List<CityViewModel> GetCities()
		{
			return _lexiconDb.Cities
					.Select(c => new CityViewModel
					{
						Name = c.Name,
						CityId = c.CityId,
						Population = c.Population,
						CountryId = c.CountryId,
						CountryName = c.Country.Name,
					}).ToList();
		}
	}



}
