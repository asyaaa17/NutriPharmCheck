using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {

        }
        public DbSet<Drugs> Drugs { get; set; }
        public DbSet<InteractionType> InteractionType { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Heabs> Heabs { get; set; }
        public DbSet<Interaction> Interactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
