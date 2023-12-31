using MatrimonyWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MatrimonyWebApi.Data
{
    public class MatrimonyDbContext : DbContext
    {
        public MatrimonyDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
                
        }

        //table references
        public DbSet<CountryMaster> Country { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<CityMaster> CityMasters{ get; set; }
        public DbSet<ReligionMaster> ReligionMasters{ get; set; }
        public DbSet<CasteMaster> CasteMasters{ get; set; }
        public DbSet<GenderMaster> GenderMasters{ get; set; }
        public DbSet<MaritialStatusMaster> MaritialStatusMasters{ get; set; }
        public DbSet<AdminMaster> AdminMasters{ get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<InterestStatusMaster> InterestStatusMasters { get; set; }

        //seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for country master
            modelBuilder.Entity<CountryMaster>().HasData(new CountryMaster { CountryId = 1 , CountryName = "India" });

            //seed data for Religion Master
            modelBuilder.Entity<ReligionMaster>()
                .HasData(new ReligionMaster
                {
                    ReligionId = Guid.Parse("08c6ab3b-97df-4959-8390-e676d35b8ceb"),
                    ReligionName = "Hindu"
                });

            //gender master

            var genderList = new List<GenderMaster>
            {
                new GenderMaster
                {
                    GenderId = 1,
                    Gender = "Male"
                },
                new GenderMaster
                {
                    GenderId = 2,
                    Gender = "Female"
                },
                new GenderMaster
                {
                    GenderId = 3,
                    Gender = "Other"
                }
            };

            modelBuilder.Entity<GenderMaster>()
                .HasData(genderList);

            //maritial status
            var maritialStatusList = new List<MaritialStatusMaster>
            {
                new MaritialStatusMaster
                {
                    MaritialStatusId = 1,
                    MaritialStatus = "Unmarried"
                },
                new MaritialStatusMaster
                {
                    MaritialStatusId = 2,
                    MaritialStatus = "Widow"
                },
                new MaritialStatusMaster
                {
                    MaritialStatusId = 3,
                    MaritialStatus = "Divorced"
                }
            };

            modelBuilder.Entity<MaritialStatusMaster>().HasData(maritialStatusList);

            //admin master
            modelBuilder.Entity<AdminMaster>()
                .HasData(new AdminMaster
                {
                    UserId = Guid.Parse("dd467971-80d6-43a6-a1ab-8b64cd25dedd"),
                    UserName = "admin",
                    Password = "admin"
                });

            //interest status master
            var interestStatusList = new List<InterestStatusMaster>
            {
                new InterestStatusMaster
                {
                    InterestStatusId = 1,
                    InterestStatus = "Open"
                },
                new InterestStatusMaster
                {
                    InterestStatusId = 2,
                    InterestStatus = "Accepted"
                },
                new InterestStatusMaster
                {
                    InterestStatusId = 3,
                    InterestStatus = "Rejected"
                }
            };

            modelBuilder.Entity<InterestStatusMaster>().HasData(interestStatusList);

            //================ Foreign Key Relations ===============================

            //Country Master
            modelBuilder.Entity<CountryMaster>()
                .HasMany(e => e.States)
                .WithOne(e => e.Country)
                .HasForeignKey(e => e.CountryIdRef)
                .IsRequired();

            //State Master
            modelBuilder.Entity<StateMaster>()
                .HasMany(e => e.Cities)
                .WithOne(e => e.StateMaster)
                .HasForeignKey(e => e.StateIdRef)
                .IsRequired();

            //Religion Master
            modelBuilder.Entity<ReligionMaster>()
                .HasMany(e => e.Castes)
                .WithOne(e => e.ReligionMaster)
                .HasForeignKey(e => e.ReligionIdRef)
                .IsRequired();
        }
    }
}
