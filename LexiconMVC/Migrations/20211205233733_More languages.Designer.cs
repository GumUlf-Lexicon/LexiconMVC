﻿// <auto-generated />
using LexiconMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LexiconMVC.Migrations
{
    [DbContext(typeof(LexiconDbContext))]
    [Migration("20211205233733_More languages")]
    partial class Morelanguages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LexiconMVC.Models.CityModel", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CountryId = 1,
                            Name = "Hillville",
                            Population = 6231
                        },
                        new
                        {
                            CityId = 2,
                            CountryId = 2,
                            Name = "Metropolis",
                            Population = 1583154
                        },
                        new
                        {
                            CityId = 3,
                            CountryId = 2,
                            Name = "Atlantis",
                            Population = 2153
                        },
                        new
                        {
                            CityId = 4,
                            CountryId = 1,
                            Name = "Blackforest",
                            Population = 184
                        },
                        new
                        {
                            CityId = 5,
                            CountryId = 3,
                            Name = "Woodlands",
                            Population = 7546
                        },
                        new
                        {
                            CityId = 6,
                            CountryId = 2,
                            Name = "Cavetown",
                            Population = 15462
                        },
                        new
                        {
                            CityId = 7,
                            CountryId = 3,
                            Name = "Castle Island",
                            Population = 29
                        },
                        new
                        {
                            CityId = 8,
                            CountryId = 1,
                            Name = "New Ironville",
                            Population = 1531
                        },
                        new
                        {
                            CityId = 9,
                            CountryId = 4,
                            Name = "Leppapolis",
                            Population = 14318
                        },
                        new
                        {
                            CityId = 10,
                            CountryId = 4,
                            Name = "Blue Lake City",
                            Population = 98531
                        },
                        new
                        {
                            CityId = 11,
                            CountryId = 2,
                            Name = "Spranley Hill",
                            Population = 8546
                        },
                        new
                        {
                            CityId = 12,
                            CountryId = 1,
                            Name = "Silicone Mountain",
                            Population = 954
                        },
                        new
                        {
                            CityId = 13,
                            CountryId = 1,
                            Name = "New Nessie City",
                            Population = 64564
                        },
                        new
                        {
                            CityId = 14,
                            CountryId = 1,
                            Name = "Smalltown",
                            Population = 3401
                        });
                });

            modelBuilder.Entity("LexiconMVC.Models.CountryModel", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("CountryId");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "Snowland",
                            Population = 643465
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "Tingia",
                            Population = 9359342
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "Portimien",
                            Population = 24465
                        },
                        new
                        {
                            CountryId = 4,
                            Name = "Vilmanie",
                            Population = 35419
                        });
                });

            modelBuilder.Entity("LexiconMVC.Models.LanguageModel", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("LanguageId");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            Name = "Esperanto"
                        },
                        new
                        {
                            LanguageId = 2,
                            Name = "Klingon"
                        },
                        new
                        {
                            LanguageId = 3,
                            Name = "Aurorish"
                        },
                        new
                        {
                            LanguageId = 4,
                            Name = "Snowlandian"
                        },
                        new
                        {
                            LanguageId = 5,
                            Name = "Portigo"
                        },
                        new
                        {
                            LanguageId = 6,
                            Name = "Moramini"
                        },
                        new
                        {
                            LanguageId = 7,
                            Name = "Brindish"
                        },
                        new
                        {
                            LanguageId = 8,
                            Name = "Vigakolin"
                        },
                        new
                        {
                            LanguageId = 9,
                            Name = "Stellian"
                        },
                        new
                        {
                            LanguageId = 10,
                            Name = "Elfdahlian"
                        });
                });

            modelBuilder.Entity("LexiconMVC.Models.PersonLanguageModel", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguage");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            LanguageId = 3
                        },
                        new
                        {
                            PersonId = 1,
                            LanguageId = 2
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 5,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 13,
                            LanguageId = 2
                        },
                        new
                        {
                            PersonId = 7,
                            LanguageId = 3
                        },
                        new
                        {
                            PersonId = 7,
                            LanguageId = 1
                        });
                });

            modelBuilder.Entity("LexiconMVC.Models.PersonModel", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("PersonId");

                    b.HasIndex("CityId");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            CityId = 1,
                            Name = "Anne Green",
                            PhoneNumber = "555-6745-343"
                        },
                        new
                        {
                            PersonId = 2,
                            CityId = 2,
                            Name = "Bob Woodyland",
                            PhoneNumber = "555-4342-764"
                        },
                        new
                        {
                            PersonId = 3,
                            CityId = 4,
                            Name = "Chris Pillow",
                            PhoneNumber = "555-6433-654"
                        },
                        new
                        {
                            PersonId = 4,
                            CityId = 4,
                            Name = "Diana Wald",
                            PhoneNumber = "555-7436-445"
                        },
                        new
                        {
                            PersonId = 5,
                            CityId = 2,
                            Name = "Erica Bobcat",
                            PhoneNumber = "555-1272-237"
                        },
                        new
                        {
                            PersonId = 6,
                            CityId = 11,
                            Name = "Fred Stone",
                            PhoneNumber = "555-2383-278"
                        },
                        new
                        {
                            PersonId = 7,
                            CityId = 3,
                            Name = "Georgina Fiveling",
                            PhoneNumber = "555-1392-865"
                        },
                        new
                        {
                            PersonId = 8,
                            CityId = 5,
                            Name = "Hank Red",
                            PhoneNumber = "555-6547-378"
                        },
                        new
                        {
                            PersonId = 9,
                            CityId = 3,
                            Name = "Ivan Bow",
                            PhoneNumber = "555-1010-001"
                        },
                        new
                        {
                            PersonId = 10,
                            CityId = 12,
                            Name = "Joanne Guidebird",
                            PhoneNumber = "555-7256-434"
                        },
                        new
                        {
                            PersonId = 11,
                            CityId = 1,
                            Name = "Kelly Flood",
                            PhoneNumber = "555-1522-941"
                        },
                        new
                        {
                            PersonId = 12,
                            CityId = 3,
                            Name = "Liam Baker",
                            PhoneNumber = "555-4324-555"
                        },
                        new
                        {
                            PersonId = 13,
                            CityId = 9,
                            Name = "Melly Greenfrog",
                            PhoneNumber = "555-3831-197"
                        });
                });

            modelBuilder.Entity("LexiconMVC.Models.CityModel", b =>
                {
                    b.HasOne("LexiconMVC.Models.CountryModel", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LexiconMVC.Models.PersonLanguageModel", b =>
                {
                    b.HasOne("LexiconMVC.Models.LanguageModel", "Language")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LexiconMVC.Models.PersonModel", "Person")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LexiconMVC.Models.PersonModel", b =>
                {
                    b.HasOne("LexiconMVC.Models.CityModel", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
