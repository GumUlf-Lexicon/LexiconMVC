using System.Collections.Generic;

namespace LexiconMVC.Models
{
	public class PeopleRegister
	{
		private static readonly List<Person> _personList = new List<Person>();

		private static int _currentPersonId = 0;

		public static bool HasBeenPopulated { get; set; } = false;

		public bool Populate()
		{
			PeopleRegister people = new PeopleRegister();

				_ = people.Add("Anne Green", "555-6745-343", "Hillville");
				_ = people.Add("Bob Woodyland", "555-4342-764", "Metropolis");
				_ = people.Add("Chris Pillow", "555-6433-654", "Atlantis");
				_ = people.Add("Diana Wald", "555-7436-445", "Blackforest");
				_ = people.Add("Erica Bobcat", "555-1272-237", "Woodlands");
				_ = people.Add("Fred Stone", "555-2383-278", "Cavetown");
				_ = people.Add("Georgina Fiveling", "555-1392-865", "Castle Island");
				_ = people.Add("Hank Red", "555-6547-378", "New Ironville");
				_ = people.Add("Ivan Bow", "555-1010-001", "Leppapolis");
				_ = people.Add("Joanne Guidebird", "555-7256-434", "Blue Lake");
				_ = people.Add("Kelly Flood", "555-1522-941", "Spranley Hill");
				_ = people.Add("Liam Baker", "555-4324-555", "Silicone Mountain");
				_ = people.Add("Melly Greenfrog", "555-3831-197", "New Nessie City");

			return true;
		}


		public Person Add(string name, string phoneNumber, string city)
		{
			Person newPerson = new Person(name, phoneNumber, city, ++_currentPersonId);
			_personList.Add(newPerson);
			return newPerson;
		}

		public bool Remove(Person person)
		{
			return _personList.Remove(person);
		}

		public List<Person> GetPersons()
		{
			return _personList;
		}

		public Person GetPerson(int personId)
		{
			return _personList.Find(p => p.PersonId == personId);
		}
	}
}
