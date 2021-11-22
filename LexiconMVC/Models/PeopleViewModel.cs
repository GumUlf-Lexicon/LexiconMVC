using System.Collections.Generic;
using System.ComponentModel;

namespace LexiconMVC.Models
{

	// PeopleViewModel
	// - Container for the information you need in
	// your people view
	public class PeopleViewModel
	{
		public CreatePersonViewModel CreatePersonVM { get; set; } = new CreatePersonViewModel();

		public List<Person> PersonListView { get; set; }

		[DisplayName("Filter: ")]
		public string SearchPhrase { get; set; } = null;

		public PeopleViewModel()
		{
			PersonListView = new List<Person>();
		}

		public PeopleViewModel(List<Person> personList)
		{
			PersonListView = personList;
		}

	}
}
