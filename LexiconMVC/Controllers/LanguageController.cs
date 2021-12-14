using LexiconMVC.Data;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LexiconMVC.Controllers
{
	[Authorize(Roles = "admin")]
	public class LanguageController: Controller
	{

		private readonly LexiconDbContext _lexiconDb;


		public LanguageController(LexiconDbContext lexiconDb)
		{
			_lexiconDb = lexiconDb;
		}

		public IActionResult Index()
		{ 
			return View();
		}


		// Get a list of languages in the languages register
		[HttpGet]
		public IActionResult GetLanguages()
		{
			List<LanguageModel> languages = _lexiconDb.Languages.ToList();
			return PartialView("_partialLanguageList", languages);
		}


		// Get a specific language in the languages register
		[HttpPost]
		public IActionResult GetLanguageById(int languageId)
		{
			List<LanguageModel> languages =
				_lexiconDb.Languages
				.Where(language => language.LanguageId == languageId)
				.ToList();

			return PartialView("_partialLanguageList", languages);
		}

		// Remove a specific language from the register
		[HttpPost]
		public IActionResult RemoveLanguageById(int languageId)
		{
			LanguageModel languageToRemove =
				(from language in _lexiconDb.Languages.ToList()
				 where language.LanguageId == languageId
				 select language).FirstOrDefault();

			if(!(languageToRemove is null))
			{
				_ = _lexiconDb.Languages.Remove(languageToRemove);
				_lexiconDb.SaveChanges();
				// The language was removed
				return StatusCode(200);
			}

			// The language was not removed, the language probably
			// was not in the register
			return StatusCode(404);
		}


		/****************************************/

		[HttpGet]
		public IActionResult AddLanguage()
		{
			LanguageAddEditViewModel languageViewModel = new LanguageAddEditViewModel()
			{
				SiteTitle = "Add Language",
				SelectedAction = "AddLanguage",
				SubmitButtonText = "Add Language"			
			};

			return View("AddEditLanguage", languageViewModel);
		}


		[HttpPost]
		public IActionResult AddLanguage(LanguageAddEditViewModel newLanguage)
		{
			if(!ModelState.IsValid)
			{
				newLanguage.SiteTitle = "Add Language";
				newLanguage.SelectedAction = "AddLanguage";
				newLanguage.SubmitButtonText = "Add Language";

				return View("AddEditLanguage", newLanguage);
			}

			LanguageModel languageToAdd = new LanguageModel
			{
				Name = newLanguage.Name,
			};
			_lexiconDb.Languages.Add(languageToAdd);
			_lexiconDb.SaveChanges();

			return RedirectToAction("Index");

		}


		[HttpGet]
		public IActionResult EditLanguage(int languageId)
		{
			LanguageModel languageToEdit = _lexiconDb.Languages
				.Where(language => language.LanguageId == languageId)
				.FirstOrDefault();

			if(languageToEdit is null)
			{
				ViewData["UserMessages"] = "Language does not exist";

				return RedirectToAction("Index");
			}

			LanguageAddEditViewModel languageViewModel = new LanguageAddEditViewModel()
			{
				// Page info
				SiteTitle = "Edit Language",
				SelectedAction = "EditLanguage",
				SubmitButtonText = "Update Language",

				// Language info
				LanguageId = languageId,
				Name = languageToEdit.Name
			};

			return View("AddEditLanguage", languageViewModel);
		}


		[HttpPost]
		public IActionResult EditLanguage(LanguageAddEditViewModel updatedLanguage)
		{

			if(!ModelState.IsValid)
			{
				return RedirectToAction("AddEditLanguage", updatedLanguage.LanguageId);
			}

			// Get language model to be able to edit the language
			LanguageModel languageToEdit = _lexiconDb.Languages
				.Where(language => language.LanguageId == updatedLanguage.LanguageId)
				.FirstOrDefault();


			// The language does not exist, go back to first page
			if(languageToEdit is null)
			{
				ViewData["Languages"] = new SelectList(_lexiconDb.Languages, "LanguageId", "Name");
				ViewData["UserMessages"] = "Language does not exist";

				return View("Index");
			}


			// If the name has changed, update it
			if(!updatedLanguage.Name.Equals(languageToEdit.Name))
				languageToEdit.Name = updatedLanguage.Name;

			// Save the updated language information to the database
			_lexiconDb.SaveChanges();

			ViewData["Languages"] = new SelectList(_lexiconDb.Languages, "LanguageId", "Name");
			ViewData["UserMessages"] = "Language updated";

			return View("Index");
		}

	}
}
