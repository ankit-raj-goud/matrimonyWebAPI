using MatrimonyWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MatrimonyWebApi.Data
{
    public class MatrimonyDbContext : DbContext
    {
        public MatrimonyDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
                
        }

        //table references
        public DbSet<Country> Country { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<CityMaster> CityMasters{ get; set; }
        public DbSet<ReligionMaster> ReligionMasters{ get; set; }
        public DbSet<CasteMaster> CasteMasters{ get; set; }

        //seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for country master
            modelBuilder.Entity<Country>().HasData(new Country { CoutnryId = 1 , CountryName = "India" });

            //seed data for Religion Master
            modelBuilder.Entity<ReligionMaster>()
                .HasData(new ReligionMaster
                {
                    ReligionId = Guid.Parse("08c6ab3b-97df-4959-8390-e676d35b8ceb"),
                    ReligionName = "Hindu"
                });
        }
    }
}
