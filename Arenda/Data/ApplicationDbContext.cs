using Arenda.Areas.Identity.Pages.Account;
using Arenda.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arenda.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Arendator> Arendators { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<CityArea> CityAreas { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<PaymentFrequency> PaymentFrequencies { get; set; }
        public DbSet<LegalEntity> LegalEntities { get; set; }
        public DbSet<PhysicalPerson> PhysicalPersons { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Penalty> Penalty { get; set; }
        public DbSet<Premise> Premises { get; set;}
        public DbSet<TypeOfFinishing> TypeOfFinishing { get; set;}
        public DbSet<RentedPremise> RentedPremises { get; set; }
        public DbSet<RentPurpose> RentPurposes { get; set; }
        public DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Создание начальной роли
            var adminRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            // Создание начального пользователя
            var adminUserId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Temp1234*"),
                SecurityStamp = string.Empty // Обычно используется для смены пароля, в данном случае может быть пустым
            });

            // Привязка пользователя к роли
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });

            List<CityArea> cities = new List<CityArea> { 
                new CityArea()
                {
                    Id = 1,
                    Name = "Дзержинский район"
                },
                new CityArea()
                {
                    Id = 2,
                    Name = "Железнодорожный район"
                },
                new CityArea()
                {
                    Id = 3,
                    Name = "Заельцовский район"
                },
                new CityArea()
                {
                    Id = 4,
                    Name = "Калининский район"
                },
                new CityArea() 
                {
                    Id = 5,
                    Name = "Кировский район"
                },
                new CityArea()
                {
                    Id = 6,
                    Name = "Ленинский район"
                },
                new CityArea()
                {
                    Id = 7,
                    Name = "Октябрьский район"
                },
                new CityArea()
                {
                    Id = 8,
                    Name = "Первомайский район"
                },
                new CityArea()
                {
                    Id = 9,
                    Name = "Советский район"
                },
                new CityArea()
                {
                    Id = 10,
                    Name = "Центральный район"
                }
            };
            modelBuilder.Entity<CityArea>().HasData(cities);

            List<TypeOfFinishing> typeOfFinishings = new List<TypeOfFinishing>()
            {
                new TypeOfFinishing()
                {
                    Id = 1,
                    Name = "Обычная"
                },
                new TypeOfFinishing()
                {
                    Id = 2,
                    Name = "Улучшенная"
                },
                new TypeOfFinishing()
                {
                    Id = 3,
                    Name = "Евроремонт"
                }
            };
            modelBuilder.Entity<TypeOfFinishing>().HasData(typeOfFinishings);

            List<PaymentFrequency> paymentFrequency = new List<PaymentFrequency>()
            {
                new PaymentFrequency()
                {
                    Id = 1,
                    Name = "Ежемесячно"
                },
                new PaymentFrequency()
                {
                    Id = 2,
                    Name = "Поквартально"
                },
                new PaymentFrequency()
                {
                    Id = 3,
                    Name = "Ежегодно"
                }
            };
            modelBuilder.Entity<PaymentFrequency>().HasData(paymentFrequency);

            List<Street> streets = new List<Street>()
            {
                new Street()
                {
                    Id = 1,
                    Name = "Красный проспект"
                },
                new Street()
                {
                    Id = 2,
                    Name = "Улица Ленина"
                }
            };
            modelBuilder.Entity<Street>().HasData(streets);

            var banks = new List<Bank>()
            {
                new Bank()
                {
                    Id = 1,
                    Name = "Сбербанк"
                }
            };
            modelBuilder.Entity<Bank>().HasData(banks);

            List<RentPurpose> rentPurposes = new List<RentPurpose>()
            {
                new RentPurpose()
                {
                    Id = 1,
                    Name = "Офис"
                },
                new RentPurpose()
                {
                    Id = 2,
                    Name = "Киоск"
                },
                new RentPurpose()
                {
                    Id = 3,
                    Name = "Склад"
                }
            };
            modelBuilder.Entity<RentPurpose>().HasData(rentPurposes);

            var phys = new PhysicalPerson()
            {
                Id = 1,
                FirstName = "test",
                SecondName = "test",
                LastName = "test",
                PasportSerial = "123",
                PasportNumber = "123",
                IssuedByWhom = "test",
                PhoneNumber = "test",
            };
            modelBuilder.Entity<PhysicalPerson>().HasData(phys);

            var legalEntity = new LegalEntity()
            {
                Id = 2,
                FirstName = "test",
                SecondName = "test",
                LastName = "test",
                BankId = 1,
                BuildingNumber = 1,
                INN = "123123",
                PaymentAccount = "1",
                StreetId = 1,
                PhoneNumber = "test"
            };
            modelBuilder.Entity<LegalEntity>().HasData(legalEntity);
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Temp1234*").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

    }
}
