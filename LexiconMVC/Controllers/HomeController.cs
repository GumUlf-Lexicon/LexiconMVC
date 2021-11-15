using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Controllers
{
	public class HomeController: Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}

		public IActionResult Projects()
		{
			return View();
		}

		public IActionResult GuessingGame()
		{
			// Get a new random secret number for the player to guess
			HttpContext.Session.SetInt32("secretNumber", new Random().Next(1, 101));

			// Clearing to be safe
			ViewBag.playerWon = 0;
			ViewBag.guessResultString = null;
			return View();
		}

		[HttpPost]
		public IActionResult GuessingGame(string playerGuess)
		{
			// Recovering the secret number to be able to se if player guess right
			int secretNumber = HttpContext.Session.GetInt32("secretNumber") ?? 0;

			// 0 = player has not won, 1 = player has won
			ViewBag.playerWon = 0;

			if(!int.TryParse(playerGuess, out int guess))
			{
				// We only allow interger numbers
				ViewBag.guessResultString = "That is not a integer number!";
			}
			else if(guess <= 0 || guess > 100)
			{
				// The guess must be within valid range
				ViewBag.guessResultString = "Your guess must be between 1 and 100.";
			}
			else if(secretNumber <= 0 || secretNumber > 100)
			{
				// Just check if the secret number is still valid
				// Maybe the player cleard the cookies, or the
				// session timed out.
				ViewBag.guessResultString = "The secret number was lost, a new number is generated.";

				// As we don't have a valid secret number, make a new one
				HttpContext.Session.SetInt32("secretNumber", new Random().Next(1, 101));
			}
			else if(guess < secretNumber)
			{
				ViewBag.guessResultString = $"The secret number is larger then your guess ({guess}).";
			}
			else if(guess > secretNumber)
			{
				ViewBag.guessResultString = $"The secret number is smaller then your guess ({guess}).";
			}
			else if(guess == secretNumber)
			{
				ViewBag.guessResultString = $"Congratulations!!! You guessed the right number ({secretNumber})!";

				// 1 = player won
				ViewBag.playerWon = 1;
			}
			else
			{
				// Eh ... IDK
				ViewBag.guessResultString = "Unkown error!";
			}
			return View();
		}
	}
}
