using Microsoft.EntityFrameworkCore;
using PersonasHamlet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonasHamlet.Data
{
    public class PersonasDbContext : DbContext
    {
        public PersonasDbContext(DbContextOptions<PersonasDbContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .Property(p => p.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Persona>()
                .Property(p => p.Name).HasColumnType("nvarchar(30)").HasMaxLength(30).IsRequired();

            modelBuilder.Entity<Persona>()
                .Property(p => p.LastName).HasColumnType("nvarchar(30)").HasMaxLength(30).IsRequired();

            
        }
    }
}
