using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC.Models
{

	// Person
	// – Person data.
	public class Person
	{
		private static int currentPersonId = 0;

		[DisplayName("Person ID")]
		public int PersonId { get; private set; }


		private string _name;

		[DisplayName("Name")]
		public string Name
		{
			get { return _name; }
			set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Person's name cannot be empty!");
				_name = value;
			}
		}

		private string _phoneNumber;

		[DisplayName("Phone number")]
		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Person's phone number cannot be empty!");
				_phoneNumber = value;
			}
		}


		private string _city;

		[DisplayName("City")]
		public string City {
			get { return _city; }
			set 
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Person's city cannot be empty!");
				_city = value;
			}
		}

		public Person(string name, string phoneNumber, string city)
		{
			Name = name;
			PhoneNumber = phoneNumber;
			City = city;
			PersonId = ++currentPersonId;
		}
	}
}
