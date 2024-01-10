﻿// <auto-generated />
using System;
using Arenda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Arenda.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Arenda.Models.Arendator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Arendators");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Arendator");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Arenda.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Banks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Сбербанк"
                        });
                });

            modelBuilder.Entity("Arenda.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityAreaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumberOfBuilding")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PremisesCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StreetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CityAreaId");

                    b.HasIndex("StreetId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Arenda.Models.CityArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CityAreas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Дзержинский район"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Железнодорожный район"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Заельцовский район"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Калининский район"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Кировский район"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ленинский район"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Октябрьский район"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Первомайский район"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Советский район"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Центральный район"
                        });
                });

            modelBuilder.Entity("Arenda.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("TEXT");

                    b.Property<int>("ArendatorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndOfContract")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentFrequencyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartOfContract")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArendatorId");

                    b.HasIndex("PaymentFrequencyId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Arenda.Models.PaymentFrequency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PaymentFrequencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ежемесячно"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Поквартально"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ежегодно"
                        });
                });

            modelBuilder.Entity("Arenda.Models.Payments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("RentedPremiseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RentedPremiseId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Arenda.Models.Penalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContractId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Penalty");
                });

            modelBuilder.Entity("Arenda.Models.Premise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuildingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("NumberExist")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PremiseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeOfFinishingId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("UsableArea")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("TypeOfFinishingId");

                    b.ToTable("Premises");
                });

            modelBuilder.Entity("Arenda.Models.RentPurpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RentPurposes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Офис"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Киоск"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Склад"
                        });
                });

            modelBuilder.Entity("Arenda.Models.RentedPremise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContractId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PremiseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RentCost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RentPurposeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RentalPeriod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("PremiseId");

                    b.HasIndex("RentPurposeId");

                    b.ToTable("RentedPremises");
                });

            modelBuilder.Entity("Arenda.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Streets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Красный проспект"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Улица Ленина"
                        });
                });

            modelBuilder.Entity("Arenda.Models.TypeOfFinishing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TypeOfFinishing");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Обычная"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Улучшенная"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Евроремонт"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c9e4c47b-538e-4897-aa49-a0b391a49f93",
                            ConcurrencyStamp = "e115e11d-0eac-471f-a513-300f3e7963e5",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c4bd6a28-f878-49f9-a950-8b81c9313783",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c65446cb-0fec-4403-81ca-45b9a1ee82ad",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKoOucBy/l5IByX+6kiQgny3zudRqKfTDS9Gs3xeN2LoDjH2wRE2ag3J6+Q9gQJ+2g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "c4bd6a28-f878-49f9-a950-8b81c9313783",
                            RoleId = "c9e4c47b-538e-4897-aa49-a0b391a49f93"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Arenda.Models.LegalEntity", b =>
                {
                    b.HasBaseType("Arenda.Models.Arendator");

                    b.Property<int>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BuildingNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentAccount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StreetId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("BankId");

                    b.HasIndex("StreetId");

                    b.HasDiscriminator().HasValue("LegalEntity");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            FirstName = "test",
                            LastName = "test",
                            PhoneNumber = "test",
                            SecondName = "test",
                            BankId = 1,
                            BuildingNumber = 1,
                            INN = "123123",
                            PaymentAccount = "1",
                            StreetId = 1
                        });
                });

            modelBuilder.Entity("Arenda.Models.PhysicalPerson", b =>
                {
                    b.HasBaseType("Arenda.Models.Arendator");

                    b.Property<string>("IssuedByWhom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasportNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasportSerial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("PhysicalPerson");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "test",
                            LastName = "test",
                            PhoneNumber = "test",
                            SecondName = "test",
                            IssuedByWhom = "test",
                            PasportNumber = "123",
                            PasportSerial = "123"
                        });
                });

            modelBuilder.Entity("Arenda.Models.Building", b =>
                {
                    b.HasOne("Arenda.Models.CityArea", "CityArea")
                        .WithMany()
                        .HasForeignKey("CityAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arenda.Models.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityArea");

                    b.Navigation("Street");
                });

            modelBuilder.Entity("Arenda.Models.Contract", b =>
                {
                    b.HasOne("Arenda.Models.Arendator", "Arendator")
                        .WithMany()
                        .HasForeignKey("ArendatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arenda.Models.PaymentFrequency", "PaymentFrequency")
                        .WithMany()
                        .HasForeignKey("PaymentFrequencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arendator");

                    b.Navigation("PaymentFrequency");
                });

            modelBuilder.Entity("Arenda.Models.Payments", b =>
                {
                    b.HasOne("Arenda.Models.RentedPremise", "RentedPremise")
                        .WithMany()
                        .HasForeignKey("RentedPremiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentedPremise");
                });

            modelBuilder.Entity("Arenda.Models.Penalty", b =>
                {
                    b.HasOne("Arenda.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Arenda.Models.Premise", b =>
                {
                    b.HasOne("Arenda.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arenda.Models.TypeOfFinishing", "TypeOfFinishing")
                        .WithMany()
                        .HasForeignKey("TypeOfFinishingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("TypeOfFinishing");
                });

            modelBuilder.Entity("Arenda.Models.RentedPremise", b =>
                {
                    b.HasOne("Arenda.Models.Contract", "Contract")
                        .WithMany("rentedPremises")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arenda.Models.Premise", "Premise")
                        .WithMany()
                        .HasForeignKey("PremiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arenda.Models.RentPurpose", "RentPurpose")
                        .WithMany()
                        .HasForeignKey("RentPurposeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Premise");

                    b.Navigation("RentPurpose");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Arenda.Models.LegalEntity", b =>
                {
                    b.HasOne("Arenda.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arenda.Models.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Street");
                });

            modelBuilder.Entity("Arenda.Models.Contract", b =>
                {
                    b.Navigation("rentedPremises");
                });
#pragma warning restore 612, 618
        }
    }
}
