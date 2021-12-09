using LexiconMVC.Data;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Controllers
{
	[Authorize(Roles = "admin")]
	public class CityController: Controller
	{
		private readonly LexiconDbContext _lexiconDb;

		public CityController(LexiconDbContext lexiconDb)
		{
			_lexiconDb = lexiconDb;
		}

		public IActionResult Index()
		{
			return View();
		}


		// Get a list of cities in the cities register
		[HttpGet]
		public IActionResult GetCities()
		{
			List<CityModel> cities = _lexiconDb.Cities
				.Include(city => city.Country)
				.Where(city => city.CountryId == city.Country.CountryId)
				.ToList();
			return PartialView("_partialCityList", cities);
		}


		// Get a specific city in the cities register
		[HttpPost]
		public IActionResult GetCityById(int cityId)
		{
			List<CityModel> cities =
				_lexiconDb.Cities
				.Include(city => city.Country)
				.Where(city => city.CityId == cityId)
				.Where(city => city.CountryId == city.Country.CountryId)
				.ToList();

			return PartialView("_partialCityList", cities);
		}

		// Remove a specific city from the register
		[HttpPost]
		public IActionResult RemoveCityById(int cityId)
		{
			CityModel cityToRemove =
				(from city in _lexiconDb.Cities.ToList()
				 where city.CityId == cityId
				 select city).FirstOrDefault();

			if(!(cityToRemove is null))
			{
				_ = _lexiconDb.Cities.Remove(cityToRemove);
				_lexiconDb.SaveChanges();
				// The city was removed
				return StatusCode(200);
			}

			// The city was not removed, the city probably
			// was not in the register
			return StatusCode(404);
		}
	}


}

