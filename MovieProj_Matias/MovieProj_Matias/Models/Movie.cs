using System;
using System.Collections.Generic;


namespace MovieProj_Matias.Models
{
    public class Movie
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int GenreID { get; set; }


        //refer to the genre model
        //public ICollection<Genre> Genre { get; set; }


    }
}