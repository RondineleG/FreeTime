using FreeTime.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeTime.Data
{
    public class PersonagenContext: DbContext
    {
        public PersonagenContext(DbContextOptions<PersonagenContext> options) : base(options)
        {
        }
        public DbSet<Personagen> Personagens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Personagen>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}