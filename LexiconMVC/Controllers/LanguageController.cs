using LexiconMVC.Data;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LexiconMVC.Controllers
{
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
	}
}
