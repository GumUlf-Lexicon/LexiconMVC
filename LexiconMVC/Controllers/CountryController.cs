using LexiconMVC.Data;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LexiconMVC.Controllers
{
	[Authorize(Roles = "admin")]
	public class CountryController: Controller
	{
		private readonly LexiconDbContext _lexiconDb;

		public CountryController(LexiconDbContext lexiconDb)
		{
			_lexiconDb = lexiconDb;
		}

		public IActionResult Index()
		{
			return View();
		}

		// Get a list of countries in the countries register
		[HttpGet]
		public IActionResult GetCountries()
		{
			List<CountryModel> countries = _lexiconDb.Countries.ToList();

			return PartialView("_partialCountryList", countries);
		}


		// Get a specific country in the countries register
		[HttpPost]
		public IActionResult GetCountryById(int countryId)
		{
			List<CountryModel> countries =
				_lexiconDb.Countries
				.Where(country => country.CountryId == countryId)
				.ToList();

			return PartialView("_partialCountryList", countries);
		}

		// Remove a specific country from the register
		[HttpPost]
		public IActionResult RemoveCountryById(int countryId)
		{
			CountryModel countryToRemove =
				(from country in _lexiconDb.Countries.ToList()
				 where country.CountryId == countryId
				 select country).FirstOrDefault();

			if(!(countryToRemove is null))
			{
				_ = _lexiconDb.Countries.Remove(countryToRemove);
				_lexiconDb.SaveChanges();
				// The country was removed
				return StatusCode(200);
			}

			// The country was not removed, the country probably
			// was not in the register
			return StatusCode(404);
		}


		[HttpGet]
		public IActionResult AddCountry()
		{
			CountryAddEditViewModel countryViewModel = new CountryAddEditViewModel()
			{
				SiteTitle = "Add Country",
				SelectedAction = "AddCountry",
				SubmitButtonText = "Add Country",
			};

			return View("AddEditCountry", countryViewModel);
		}


		[HttpPost]
		public IActionResult AddCountry(CountryAddEditViewModel newCountry)
		{
			if(!ModelState.IsValid)
			{
				newCountry.SiteTitle = "Add Country";
				newCountry.SelectedAction = "AddCountry";
				newCountry.SubmitButtonText = "Add Country";

				return View("AddEditCountry", newCountry);
			}

			CountryModel countryToAdd = new CountryModel
			{
				Name = newCountry.Name,
				Population = newCountry.Population
			};
			_lexiconDb.Countries.Add(countryToAdd);
			_lexiconDb.SaveChanges();

			return RedirectToAction("Index");

		}


		[HttpGet]
		public IActionResult EditCountry(int countryId)
		{
			CountryModel countryToEdit = _lexiconDb.Countries
				.Where(country => country.CountryId == countryId)
				.FirstOrDefault();

			if(countryToEdit is null)
			{
				ViewData["UserMessages"] = "Country does not exist";

				return RedirectToAction("Index");
			}

			CountryAddEditViewModel countryViewModel = new CountryAddEditViewModel()
			{
				// Page info
				SiteTitle = "Edit Country",
				SelectedAction = "EditCountry",
				SubmitButtonText = "Update Country",

				// Country info
				CountryId = countryId,
				Name = countryToEdit.Name,
				Population = countryToEdit.Population

			};

			return View("AddEditCountry", countryViewModel);
		}


		[HttpPost]
		public IActionResult EditCountry(CountryAddEditViewModel updatedCountry)
		{

			if(!ModelState.IsValid)
			{
				return RedirectToAction("AddEditCountry", updatedCountry.CountryId);
			}

			// Get country model to be able to edit the country
			CountryModel countryToEdit = _lexiconDb.Countries
				.Where(country => country.CountryId == updatedCountry.CountryId)
				.FirstOrDefault();


			// The country does not exist, go back to first page
			if(countryToEdit is null)
			{
				ViewData["UserMessages"] = "Country does not exist";

				return View("Index");
			}


			// If the name has changed, update it
			if(!updatedCountry.Name.Equals(countryToEdit.Name))
				countryToEdit.Name = updatedCountry.Name;

			// If the population has changed, update it
			if(updatedCountry.Population != countryToEdit.Population)
				countryToEdit.Population = updatedCountry.Population;

			// Save the updated country information to the database
			_lexiconDb.SaveChanges();

			ViewData["UserMessages"] = "Country updated";

			return View("Index");
		}

	}

}


