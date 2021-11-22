using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Controllers
{
	public class PeopleController: Controller
	{
		private static bool _isPeoplePopulated = false;

		[HttpGet]
		public IActionResult Index()
		{
			PeopleRegister people = new PeopleRegister();

			PeopleViewModel peopleVM = new PeopleViewModel(people.GetPersons());
					
			if(!_isPeoplePopulated)
			{
				_isPeoplePopulated = people.Populate();
			}

			return View(peopleVM);
		}


		[HttpPost]
		public IActionResult Index(PeopleViewModel peopleVM)
		{
			PeopleRegister people = new PeopleRegister();
			peopleVM.PersonListView.Clear();

			foreach(Person person in people.GetPersons())
			{
				if(person.Name.Contains(peopleVM.SearchPhrase, StringComparison.InvariantCultureIgnoreCase))
				{
					peopleVM.PersonListView.Add(person);
				}
			}
			return View(peopleVM);
		}



		[HttpPost]
		public IActionResult CreatePerson(CreatePersonViewModel createPersonVM)
		{

			PeopleRegister people = new PeopleRegister();
			PeopleViewModel peopleVM = new PeopleViewModel(people.GetPersons());

			if(ModelState.IsValid)
			{
				people.Add(createPersonVM.Name, createPersonVM.PhoneNumber, createPersonVM.City);
				ModelState.Clear();
				peopleVM.SearchPhrase = null;
			}

			return View("Index", peopleVM);
		}

		[HttpGet]
		public IActionResult RemovePerson(int personId)
		{
			PeopleRegister people = new PeopleRegister();
			PeopleViewModel peopleVM = new PeopleViewModel(people.GetPersons());

			_ = people.Remove(people.GetPerson(personId));

			return View("Index", peopleVM);
		}

		[HttpPost]
		public IActionResult FilterPersons(string searchPhrase)
		{
			PeopleRegister people = new PeopleRegister();
			PeopleViewModel peopleVM = new PeopleViewModel();

			if(string.IsNullOrWhiteSpace(searchPhrase))
			{
				peopleVM.SearchPhrase = null;
			}
			else
			{
				peopleVM.SearchPhrase = searchPhrase;
			}

			foreach(Person person in people.GetPersons())
			{
				if(peopleVM.SearchPhrase is null 
					|| person.Name.Contains(peopleVM.SearchPhrase, StringComparison.InvariantCultureIgnoreCase)
					|| person.City.Contains(peopleVM.SearchPhrase, StringComparison.InvariantCultureIgnoreCase))
				{
					peopleVM.PersonListView.Add(person);
				}
			}

			return View("Index", peopleVM);
		}
	}
}
