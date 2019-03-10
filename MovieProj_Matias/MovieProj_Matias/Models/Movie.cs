using System;
using System.Collections.Generic;


namespace MovieProj_Matias.Models
{
    public class Movie
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public int year { get; set; }

        public ICollection<Genre> Genre { get; set; }


    }
}