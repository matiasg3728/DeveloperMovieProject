using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieProj_Matias.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieProj_Matias.Data
{
    public class CinimaContext : DbContext
    {
        public CinimaContext(DbContextOptions<CinimaContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        /*
         * Personally I like the sound of Movies table rather than Movie table
         * But this is interesting
         * 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
         
        }
        */
    }
}
