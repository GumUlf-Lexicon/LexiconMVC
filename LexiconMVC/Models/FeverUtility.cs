namespace LexiconMVC.Models
{
	public class FeverUtility
	{
		public static string CheckForFever(string bodyTemperatureString)
		{
			if(float.TryParse(bodyTemperatureString, out float bodyTemperature))
			{
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

			return "Wrong numberformat!";

		}
	}
}
