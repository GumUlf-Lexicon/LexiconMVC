using LexiconMVC.Data;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		/***************************************************/

		[HttpGet]
		public IActionResult AddCity()
		{
			CityAddEditViewModel cityViewModel = new CityAddEditViewModel()
			{
				SiteTitle = "Add City",
				SelectedAction = "AddCity",
				SubmitButtonText = "Add City",

				Countries = _lexiconDb.Countries.Select(
					s => new SelectListItem
					{
						Selected = false,
						Text = s.Name,
						Value = s.CountryId.ToString()
					}).ToList()
			};

			return View("AddEditCity", cityViewModel);
		}


		[HttpPost]
		public IActionResult AddCity(CityAddEditViewModel newCity)
		{
			if(!ModelState.IsValid)
			{

				newCity.SiteTitle = "Add City";
				newCity.SelectedAction = "AddCity";
				newCity.SubmitButtonText = "Add City";
				newCity.Countries = _lexiconDb.Countries.Select(
					s => new SelectListItem
					{
						Selected = false,
						Text = s.Name,
						Value = s.CountryId.ToString()
					}).ToList();

				return View("AddEditCity", newCity);
			}

			CityModel cityToAdd = new CityModel
			{
				Name = newCity.Name,
				Population = newCity.Population,
				CountryId = newCity.CountryId
			};
			_lexiconDb.Cities.Add(cityToAdd);
			_lexiconDb.SaveChanges();

			return RedirectToAction("Index");

		}


		[HttpGet]
		public IActionResult EditCity(int cityId)
		{
			CityModel cityToEdit = _lexiconDb.Cities
				.Where(city => city.CityId == cityId)
				.FirstOrDefault();

			if(cityToEdit is null)
			{
				ViewData["UserMessages"] = "City does not exist";

				return RedirectToAction("Index");
			}


			CityAddEditViewModel cityViewModel = new CityAddEditViewModel()
			{
				// Page info
				SiteTitle = "Edit City",
				SelectedAction = "EditCity",
				SubmitButtonText = "Update City",

				// City info
				CityId = cityId,
				Name = cityToEdit.Name,
				Population = cityToEdit.Population,
				CountryId = cityToEdit.CountryId,

				// Available countries
				Countries = _lexiconDb.Countries.Select(
					s => new SelectListItem()
					{
						Text = s.Name,
						Value = s.CountryId.ToString()
					}).ToList()
			};

			return View("AddEditCity", cityViewModel);
		}


		[HttpPost]
		public IActionResult EditCity(CityAddEditViewModel updatedCity)
		{

			if(!ModelState.IsValid)
			{
				return RedirectToAction("AddEditCity", updatedCity.CityId);
			}

			// Get city model to be able to edit the city
			CityModel cityToEdit = _lexiconDb.Cities
				.Where(city => city.CityId == updatedCity.CityId)
				.FirstOrDefault();

			// The city does not exist, go back to first page
			if(cityToEdit is null)
			{
				ViewData["UserMessages"] = "City does not exist";

				return View("Index");
			}


			// If the name has changed, update it
			if(!updatedCity.Name.Equals(cityToEdit.Name))
				cityToEdit.Name = updatedCity.Name;

			// If the poplulation has changed, update it
			if(updatedCity.Population != cityToEdit.Population)
				cityToEdit.Population = updatedCity.Population;

			// If the country has changed, update it if the new country is valid
			if(updatedCity.CountryId != cityToEdit.CountryId
				&& _lexiconDb.Countries.Where(country => country.CountryId == updatedCity.CountryId).Count() == 1)
			{
				cityToEdit.CountryId = updatedCity.CountryId;
			}

			// Save the updated  information to the database
			_lexiconDb.SaveChanges();

			ViewData["UserMessages"] = "City updated";

			return View("Index");
		}

	}

}