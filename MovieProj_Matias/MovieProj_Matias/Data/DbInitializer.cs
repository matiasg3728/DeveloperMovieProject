using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieProj_Matias.Models;


namespace MovieProj_Matias.Data
{
    public class DbInitializer
    {
        public static void Initialize(CinimaContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }


            var genres = new Genre[]
            {
                new Genre{ Name="Drama"},
                new Genre{ Name="Comedy"},
                new Genre{ Name="Action"}
            };
            foreach (Genre g in genres)
            {
                context.Genres.Add(g);
            }
            context.SaveChanges();

            var movies = new Movie[]
            {
                new Movie{ Title="Tree Man 3 - Everywhere to go but no where to leaf", Year=2010, GenreID=1},
                new Movie{ Title="A tail of 2 kitties", Year=2002, GenreID=1},
                new Movie{ Title="Silly Bill, The Reconing Is Nye", Year=1996, GenreID=3},
                new Movie{ Title="Goobler Man, No Doobler Left Un-Dingled", Year=1996, GenreID=3},
                new Movie{ Title="War for LA, Cholopocolypse", Year=2012, GenreID=2}
            };
            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();

        }
       
    }
}
