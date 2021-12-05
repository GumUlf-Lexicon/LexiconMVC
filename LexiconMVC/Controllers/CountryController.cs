using LexiconMVC.Data;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Controllers
{
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
	}

}
