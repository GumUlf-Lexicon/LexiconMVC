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
			return View();
		}

		[HttpGet]
		public IActionResult GetPersons()
		{
			PeopleRegister people = new PeopleRegister();
			List<Person> peopleList = people.GetPersons();
			//
			//return PartialView("_partial")
			return View("Index");
		}


	}


}
