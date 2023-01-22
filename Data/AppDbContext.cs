using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTicket.Models;

namespace eTicket.Data
{
    public class AppDbContext : DbContext
    {
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base()
        {
        }

        //defining joins
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movies>().HasKey(actorMovie => new {
                actorMovie.ActorID,
                actorMovie.MovieID
            });

            modelBuilder.Entity<Actor_Movies>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movie).HasForeignKey(m => m.MovieID);

            modelBuilder.Entity<Actor_Movies>().HasOne(m => m.Actor).WithMany(am => am.Actor_Movie).HasForeignKey(m => m.ActorID);

            base.OnModelCreating(modelBuilder);
        }

        //defining table names
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Cinemas> Cinemas { get; set; }
        public DbSet<Producers> Producers { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Actor_Movies> Actors_Movies { get; set; }

    }
}
