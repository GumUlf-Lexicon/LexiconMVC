using LexiconMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC.Data
{
	public class LexiconDbContext: IdentityDbContext<ApplicationUserModel>
	{
		public LexiconDbContext(DbContextOptions<LexiconDbContext> options) : base(options) { }

		public DbSet<CountryModel> Countries { get; set; }
		public DbSet<CityModel> Cities { get; set; }
		public DbSet<PersonModel> People { get; set; }
		public DbSet<LanguageModel> Languages { get; set; }
		public DbSet<PersonLanguageModel> PersonLanguages { get; set; }
		public override DbSet<ApplicationUserModel> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);

			_ = modelBuilder.Entity<PersonLanguageModel>().HasKey(pl => new { pl.PersonId, pl.LanguageId });

			_ = modelBuilder.Entity<PersonLanguageModel>()
				.HasOne(pl => pl.Person)
				.WithMany(p => p.PersonLanguages)
				.HasForeignKey(pl => pl.PersonId);

			_ = modelBuilder.Entity<PersonLanguageModel>()
				.HasOne(pl => pl.Language)
				.WithMany(l => l.PersonLanguages)
				.HasForeignKey(pl => pl.LanguageId);


			CountrySeeding(modelBuilder);
			CitySeeding(modelBuilder);
			PersonSeeding(modelBuilder);
			LanguageSeeding(modelBuilder);
			PersonLanguageSeeding(modelBuilder);
		}



		private void PersonSeeding(ModelBuilder modelBuilder)
		{
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 1, Name = "Anne Green", PhoneNumber = "555-6745-343", CityId = 1 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 2, Name = "Bob Woodyland", PhoneNumber = "555-4342-764", CityId = 2 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 3, Name = "Chris Pillow", PhoneNumber = "555-6433-654", CityId = 4 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 4, Name = "Diana Wald", PhoneNumber = "555-7436-445", CityId = 4 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 5, Name = "Erica Bobcat", PhoneNumber = "555-1272-237", CityId = 2 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 6, Name = "Fred Stone", PhoneNumber = "555-2383-278", CityId = 11 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 7, Name = "Georgina Fiveling", PhoneNumber = "555-1392-865", CityId = 3 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 8, Name = "Hank Red", PhoneNumber = "555-6547-378", CityId = 5 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 9, Name = "Ivan Bow", PhoneNumber = "555-1010-001", CityId = 3 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 10, Name = "Joanne Guidebird", PhoneNumber = "555-7256-434", CityId = 12 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 11, Name = "Kelly Flood", PhoneNumber = "555-1522-941", CityId = 1 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 12, Name = "Liam Baker", PhoneNumber = "555-4324-555", CityId = 3 });
			_ = modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 13, Name = "Melly Greenfrog", PhoneNumber = "555-3831-197", CityId = 9 });
		}

		private void CitySeeding(ModelBuilder modelBuilder)
		{
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 1, Name = "Hillville", Population = 6231, CountryId = 1 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 2, Name = "Metropolis", Population = 1583154, CountryId = 2 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 3, Name = "Atlantis", Population = 2153, CountryId = 2 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 4, Name = "Blackforest", Population = 184, CountryId = 1 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 5, Name = "Woodlands", Population = 7546, CountryId = 3 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 6, Name = "Cavetown", Population = 15462, CountryId = 2 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 7, Name = "Castle Island", Population = 29, CountryId = 3 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 8, Name = "New Ironville", Population = 1531, CountryId = 1 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 9, Name = "Leppapolis", Population = 14318, CountryId = 4 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 10, Name = "Blue Lake City", Population = 98531, CountryId = 4 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 11, Name = "Spranley Hill", Population = 8546, CountryId = 2 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 12, Name = "Silicone Mountain", Population = 954, CountryId = 1 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 13, Name = "New Nessie City", Population = 64564, CountryId = 1 });
			_ = modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 14, Name = "Smalltown", Population = 3401, CountryId = 1 });
		}

		private void CountrySeeding(ModelBuilder modelBuilder)
		{
			_ = modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 1, Name = "Snowland", Population = 643465 });
			_ = modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 2, Name = "Tingia", Population = 9359342 });
			_ = modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 3, Name = "Portimien", Population = 24465 });
			_ = modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 4, Name = "Vilmanie", Population = 35419 });
		}

		private void LanguageSeeding(ModelBuilder modelBuilder)
		{
			_ = modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 1, Name = "Esperanto" });
			_ = modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 2, Name = "Klingon" });
			_ = modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 3, Name = "Aurorish" });
			_ = modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 4, Name = "Snowlandian" });
			_ = modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 5, Name = "Portigo" });
			_ = modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 6, Name = "Moramini" });
			_ = modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 7, Name = "Brindish" });
			_ = modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 8, Name = "Vigakolin" });
			_ = modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 9, Name = "Stellian" });
			_ = modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 10, Name = "Elfdahlian" });
		}

		private void PersonLanguageSeeding(ModelBuilder modelBuilder)
		{
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 1, LanguageId = 5 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 1, LanguageId = 4 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 1, LanguageId = 9 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 1, LanguageId = 10 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 2, LanguageId = 1 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 2, LanguageId = 10 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 3, LanguageId = 1 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 4, LanguageId = 3 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 5, LanguageId = 4 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 5, LanguageId = 6 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 5, LanguageId = 8 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 5, LanguageId = 10 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 6, LanguageId = 3 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 6, LanguageId = 5 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 7, LanguageId = 2 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 7, LanguageId = 7 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 7, LanguageId = 9 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 7, LanguageId = 3 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 8, LanguageId = 5 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 9, LanguageId = 2 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 9, LanguageId = 8 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 10, LanguageId = 8 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 11, LanguageId = 3 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 11, LanguageId = 6 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 11, LanguageId = 9 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 12, LanguageId = 4 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 12, LanguageId = 10 });
			_ = modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 13, LanguageId = 8 });
		}

	}
}