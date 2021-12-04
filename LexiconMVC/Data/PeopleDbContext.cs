using LexiconMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC.Data
{
	public class PeopleDbContext: DbContext
	{
		public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options) { }

		public DbSet<PersonModel> People { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			PersonSeeding(modelBuilder);
		}

		private static void PersonSeeding(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 1, Name = "Anne Green", PhoneNumber = "555-6745-343", City = "Hillville" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 2, Name = "Bob Woodyland", PhoneNumber = "555-4342-764", City = "Metropolis" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 3, Name = "Chris Pillow", PhoneNumber = "555-6433-654", City = "Atlantis" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 4, Name = "Diana Wald", PhoneNumber = "555-7436-445", City = "Blackforest" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 5, Name = "Erica Bobcat", PhoneNumber = "555-1272-237", City = "Woodlands" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 6, Name = "Fred Stone", PhoneNumber = "555-2383-278", City = "Cavetown" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 7, Name = "Georgina Fiveling", PhoneNumber = "555-1392-865", City = "Castle Island" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 8, Name = "Hank Red", PhoneNumber = "555-6547-378", City = "New Ironville" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 9, Name = "Ivan Bow", PhoneNumber = "555-1010-001", City = "Leppapolis" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 10, Name = "Joanne Guidebird", PhoneNumber = "555-7256-434", City = "Blue Lake" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 11, Name = "Kelly Flood", PhoneNumber = "555-1522-941", City = "Spranley Hill" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 12, Name = "Liam Baker", PhoneNumber = "555-4324-555", City = "Silicone Mountain" });
			modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 13, Name = "Melly Greenfrog", PhoneNumber = "555-3831-197", City = "New Nessie City" });
		}
	}
}