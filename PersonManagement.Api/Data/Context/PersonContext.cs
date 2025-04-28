using Microsoft.EntityFrameworkCore;
using PersonManagement.Api.Data.Entities;

namespace PersonManagement.Api.Data.Context
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
        : base(options) { }

        public DbSet<Nationality> Nationalities { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding 3 objects
            modelBuilder.Entity<Nationality>().HasData(
                new Nationality { ID = 1, Name = "American" },
                new Nationality { ID = 2, Name = "Canadian" },
                new Nationality { ID = 3, Name = "Mexican" }
            );
        }

    }
}
