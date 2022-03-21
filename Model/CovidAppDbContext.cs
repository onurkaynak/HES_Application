using Microsoft.EntityFrameworkCore;

namespace CovidApp
{
    public class CovidAppDbContext : DbContext
    {
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<District>? Districts { get; set; }
        public DbSet<Notify>? Notifies { get; set; }
        public DbSet<Passport>? Passports { get; set; }
        public DbSet<VaccinationInformation>? VaccinationInformations { get; set; }
        public DbSet<ViolationType>? ViolationTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            optionsBuilder.UseMySql("server=localhost;database=CovidAppDb;user=root;port=3306;password=toortoor", serverVersion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PhoneNumber).IsRequired();
            entity.Property(e => e.Blocked);
            entity.Property(e => e.IsVisibility);
            entity.HasOne(b => b.User).WithOne(i => i.Account).HasForeignKey<User>(b => b.AccountId);
        });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.IsCorona).IsRequired();
                entity.Property(e => e.Birthdate).IsRequired();
                entity.Property(e => e.AccountId).IsRequired();
                entity.HasMany(e => e.Passports).WithOne(r => r.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Notifies).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.VaccinationInformation).WithOne(e => e.User).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.City).WithMany().HasForeignKey(e => e.CityId);
            });
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OpenAddress).IsRequired();
                entity.HasOne(e => e.City).WithMany().HasForeignKey(e => e.CityId);
                entity.HasOne(e => e.District).WithMany().HasForeignKey(e => e.DistrictId);
            });
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.PlateCode).IsRequired();
                entity.HasMany(e => e.District).WithOne(e => e.City).HasForeignKey(e => e.CityId);

            });
            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Notify>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.ViolationSubject).IsRequired();
                entity.Property(e => e.ViolationDetail).IsRequired();
                entity.HasOne(e => e.ViolationType).WithOne(e => e.Notify).HasForeignKey<ViolationType>(e => e.NotifyId);
                entity.HasOne(e => e.Address).WithOne(e => e.Notify).HasForeignKey<Address>(e => e.NotifyId);
            });
            modelBuilder.Entity<Passport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.No).IsRequired();
                entity.Property(e => e.CountryCode).IsRequired();
            });
            modelBuilder.Entity<VaccinationInformation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.VacinationName).IsRequired();
                entity.Property(e => e.VaccinationDate).IsRequired();

            });
            modelBuilder.Entity<ViolationType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IsMaskedUsed).IsRequired();
                entity.Property(e => e.IsHygienic).IsRequired();
                entity.Property(e => e.IsSocialDistanceViolated).IsRequired();
            });
            SetDataToDB(modelBuilder);

        }
        static void SetDataToDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                            new Address
                            {
                                Id = 1,
                                OpenAddress = "Barış Mah. Beylikdüzü/İstanbul",
                                CityId = 1,
                                DistrictId = 1
                            },
                               new Address
                               {
                                   Id = 2,
                                   OpenAddress = "Cumhuriyet Mah. Avcılar/İzmir",
                                   CityId = 2,
                                   DistrictId = 2

                               },
                               new Address
                               {
                                   Id = 3,
                                   OpenAddress = "Adakent Mah. Şişli/Ankara",
                                   CityId = 3,
                                   DistrictId = 3
                               },
                                 new Address
                                 {
                                     Id = 4,
                                     OpenAddress = "Adakent Mah. Şişli/Ankara",
                                     CityId = 3,
                                     DistrictId = 3
                                 }
            );

            modelBuilder.Entity<City>().HasData(
                            new City
                            {
                                Id = 1,
                                Name = "İstanbul",
                                PlateCode = 34

                            },
                               new City
                               {
                                   Id = 2,
                                   Name = "İzmir",
                                   PlateCode = 35
                               },
                               new City
                               {
                                   Id = 3,
                                   Name = "Ankara",
                                   PlateCode = 06
                               }
            );
            modelBuilder.Entity<District>().HasData(
                            new District
                            {
                                Id = 1,
                                Name = "Beylikdüzü",
                                CityId = 1
                            },
                               new District
                               {
                                   Id = 2,
                                   Name = "Avcılar",
                                   CityId = 2,
                               },
                               new District
                               {
                                   Id = 3,
                                   Name = "Büyükçekmece",
                                   CityId = 3
                               }
            );

            modelBuilder.Entity<Account>().HasData(
                               new Account
                               {
                                   Id = 1,
                                   PhoneNumber = "1111111111",
                                   IsVisibility = false,
                                   Blocked = false

                               },
                               new Account
                               {
                                   Id = 2,
                                   PhoneNumber = "2222222222",
                                   IsVisibility = false,
                                   Blocked = false
                               },
                               new Account
                               {
                                   Id = 3,
                                   PhoneNumber = "3333333333",
                                   IsVisibility = false,
                                   Blocked = false
                               },
                               new Account
                               {
                                   Id = 4,
                                   PhoneNumber = "4444444444",
                                   IsVisibility = false,
                                   Blocked = false

                               },
                               new Account
                               {
                                   Id = 5,
                                   PhoneNumber = "5555555555",
                                   IsVisibility = false,
                                   Blocked = false
                               },
                               new Account
                               {
                                   Id = 6,
                                   PhoneNumber = "6666666666",
                                   IsVisibility = false,
                                   Blocked = false
                               },
                               new Account
                               {
                                   Id = 7,
                                   PhoneNumber = "7777777777",
                                   IsVisibility = false,
                                   Blocked = false

                               },
                               new Account
                               {
                                   Id = 8,
                                   PhoneNumber = "8888888888",
                                   IsVisibility = false,
                                   Blocked = false
                               },
                               new Account
                               {
                                   Id = 9,
                                   PhoneNumber = "9999999999",
                                   IsVisibility = false,
                                   Blocked = false
                               }

            );

            modelBuilder.Entity<User>().HasData(
                               new User
                               {
                                   Id = 1,
                                   AccountId = 1,
                                   FirstName = "Ugur",
                                   LastName = "Unsal",
                                   Gender = Gender.Male,
                                   IsCorona = true,
                                   Birthdate = new DateTime(1999, 04, 02),
                                   CityId = 1
                               },
                               new User
                               {
                                   Id = 2,
                                   AccountId = 2,
                                   FirstName = "Meryem",
                                   LastName = "Can",
                                   Gender = Gender.Female,
                                   IsCorona = true,
                                   Birthdate = new DateTime(1993, 04, 02),
                                   CityId = 1
                               },
                               new User
                               {
                                   Id = 3,
                                   AccountId = 3,
                                   FirstName = "Abidin",
                                   LastName = "Yarata",
                                   Gender = Gender.Male,
                                   IsCorona = true,
                                   Birthdate = new DateTime(1989, 04, 02),
                                   CityId = 1
                               },
                               new User
                               {
                                   Id = 4,
                                   AccountId = 4,
                                   FirstName = "Onur",
                                   LastName = "Kaynak",
                                   Gender = Gender.Male,
                                   IsCorona = true,
                                   Birthdate = new DateTime(1995, 04, 02),
                                   CityId = 2

                               },
                               new User
                               {
                                   Id = 5,
                                   AccountId = 5,
                                   FirstName = "İdil",
                                   LastName = "Nihan",
                                   Gender = Gender.Female,
                                   IsCorona = false,
                                   Birthdate = new DateTime(1997, 04, 02),
                                   CityId = 2
                               },
                               new User
                               {
                                   Id = 6,
                                   AccountId = 6,
                                   FirstName = "Seyma",
                                   LastName = "Deveci",
                                   Gender = Gender.Female,
                                   IsCorona = false,
                                   Birthdate = new DateTime(1998, 04, 02),
                                   CityId = 2
                               },
                               new User
                               {
                                   Id = 7,
                                   AccountId = 7,
                                   FirstName = "Özgür",
                                   LastName = "Öztürk",
                                   Gender = Gender.Male,
                                   IsCorona = false,
                                   Birthdate = new DateTime(1991, 04, 02),
                                   CityId = 3

                               },
                               new User
                               {
                                   Id = 8,
                                   AccountId = 9,
                                   FirstName = "Alara",
                                   LastName = "Sakarya",
                                   Gender = Gender.Female,
                                   IsCorona = false,
                                   Birthdate = new DateTime(1996, 04, 02),
                                   CityId = 3
                               },
                               new User
                               {
                                   Id = 9,
                                   AccountId = 1,
                                   FirstName = "Yağız",
                                   LastName = "Kurtay",
                                   Gender = Gender.Male,
                                   IsCorona = false,
                                   Birthdate = new DateTime(2001, 04, 02),
                                   CityId = 3
                               }

            );
        }

    }
}
