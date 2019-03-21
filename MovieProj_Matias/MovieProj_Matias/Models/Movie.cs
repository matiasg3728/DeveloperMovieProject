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
        // 3/20/19 for a second I almost uncommented. imnotgonletugetthechangeStuupid
        //public ICollection<Genre> Genre { get; set; }


    }
}