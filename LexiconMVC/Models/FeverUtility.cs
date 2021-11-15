namespace LexiconMVC.Models
{
	public class FeverUtility
	{
		// Tempereature in degrees C
		public static string CheckForFever(string bodyTemperatureString)
		{
			// Check if it is a number that has been entered
			if(float.TryParse(bodyTemperatureString, out float bodyTemperature))
			{
				// Valid number has been entered, return result
				if(bodyTemperature >= 38)
				{
					return "You have a fever! Drink water and get a lot of rest!";
				}
				else if(bodyTemperature < 35)
				{
					return "You have got hypothermia! Please get help right now!!! Try and get your temperature up!";
				}
				else
				{
					return "You do not have a fever.";
				}
			}
			else
			{
				// Maybe text has been entered, or wrong decimal symbol
				return "Wrong numberformat!";
			}

		}
	}
}
