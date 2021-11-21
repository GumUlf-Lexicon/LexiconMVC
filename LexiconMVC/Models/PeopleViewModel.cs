using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Models
{

	// PeopleViewModel
	// - Container for the information you need in
	// your people view
	public class PeopleViewModel
	{
		public CreatePersonViewModel Cpvm { get; set; } = new CreatePersonViewModel();

		public List<Person> People { get; } = new List<Person>();

		[DisplayName("Filter: ")]
		public string SearchPhrase { get; set; } = null;

		public PeopleViewModel()
		{ }

		public bool PopulatePeople()
		{
			if(People.Count == 0)
			{
				People.Add(new Person("Anne Green", "555-6745-343",  "Hillville"));
				People.Add(new Person("Bob Woodyland", "555-4342-764",  "Metropolis"));
				People.Add(new Person("Chris Pillow", "555-6433-654",  "Atlantis"));
				People.Add(new Person("Diana Wald", "555-7436-445",  "Blackforest"));
				People.Add(new Person("Erica Bobcat", "555-1272-237",  "Woodlands"));
				People.Add(new Person("Fred Stone", "555-2383-278",  "Cavetown"));
				People.Add(new Person("Georgina Fiveling", "555-1392-865",  "Castle Island"));
				People.Add(new Person("Hank Red", "555-6547-378",  "New Ironville"));
				People.Add(new Person("Ivan Bow", "555-1010-001",  "Leppapolis"));
				People.Add(new Person("Joanne Guidebird", "555-7256-434",  "Blue Lake"));
				People.Add(new Person("Kelly Flood", "555-1522-941",  "Spranley Hill"));
				People.Add(new Person("Liam Baker", "555-4324-555",  "Silicone Mountain"));
				People.Add(new Person("Melly Greenfrog", "555-3831-197",  "New Nessie City"));
				return true;
			}
			return false;

		}


	}
}
