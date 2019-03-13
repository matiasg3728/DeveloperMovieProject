using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProj_Matias.Models
{
    public class Genre
    {

        public int ID { get; set; }
        public string Name { get; set; }

        //I assume that movies can have multiple genres and genres can have multiple movies
   
        public ICollection<Movie> Movies { get; set; }

    }
}
