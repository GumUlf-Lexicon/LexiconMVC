using LexiconMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC.Data
{
	public class LexiconDbContext: DbContext
	{
		public LexiconDbContext(DbContextOptions<LexiconDbContext> options) : base(options) { }

		public DbSet<CountryModel> Countries { get; set; }
		public DbSet<CityModel> Cities { get; set; }
		public DbSet<PersonModel> People { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			CountrySeeding(modelBuilder);
			CitySeeding(modelBuilder);
			PersonSeeding(modelBuilder);
		}

		private static void PersonSeeding(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 1,		Name = "Anne Green",				PhoneNumber = "555-6745-343",	CityId = 1	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 2,		Name = "Bob Woodyland",			PhoneNumber = "555-4342-764",	CityId = 2	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 3,		Name = "Chris Pillow",			PhoneNumber = "555-6433-654", CityId = 4	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 4,		Name = "Diana Wald",				PhoneNumber = "555-7436-445", CityId = 4	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 5,		Name = "Erica Bobcat",			PhoneNumber = "555-1272-237", CityId = 2	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 6,		Name = "Fred Stone",				PhoneNumber = "555-2383-278", CityId = 11	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 7,		Name = "Georgina Fiveling",	PhoneNumber = "555-1392-865", CityId = 3	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 8,		Name = "Hank Red",				PhoneNumber = "555-6547-378", CityId = 5	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 9,		Name = "Ivan Bow",				PhoneNumber = "555-1010-001", CityId = 3	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 10,	Name = "Joanne Guidebird",		PhoneNumber = "555-7256-434", CityId = 12	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 11,	Name = "Kelly Flood",			PhoneNumber = "555-1522-941", CityId = 1	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 12,	Name = "Liam Baker",				PhoneNumber = "555-4324-555",	CityId = 3	});
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 13,	Name = "Melly Greenfrog",		PhoneNumber = "555-3831-197",	CityId = 9	});
		}

		private static void CitySeeding(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 1, Name = "Hillville", Population = 6231, CountryId = 1 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 2, Name = "Metropolis", Population = 1583154, CountryId = 2 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 3, Name = "Atlantis", Population = 2153, CountryId = 2 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 4, Name = "Blackforest", Population = 184, CountryId = 1 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 5, Name = "Woodlands", Population = 7546, CountryId = 3 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 6, Name = "Cavetown", Population = 15462, CountryId = 2 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 7, Name = "Castle Island", Population = 29, CountryId = 3 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 8, Name = "New Ironville", Population = 1531, CountryId = 1 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 9, Name = "Leppapolis", Population = 14318, CountryId = 4 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 10, Name = "Blue Lake City", Population = 98531, CountryId = 4 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 11, Name = "Spranley Hill", Population = 8546, CountryId = 2 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 12, Name = "Silicone Mountain", Population = 954, CountryId = 1 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 13, Name = "New Nessie City", Population = 64564, CountryId = 1 });
			modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 14,		Name = "Smalltown",				Population = 3401,		CountryId = 1	});
		}


		private static void CountrySeeding(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 1,		Name = "Snowland",	Population = 643465	});
			modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 2, Name = "Tingia", Population = 9359342 });
			modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 3, Name = "Portimien", Population = 24465 });
			modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 4, Name = "Vilmanie", Population = 35419 });
		}

	}
}