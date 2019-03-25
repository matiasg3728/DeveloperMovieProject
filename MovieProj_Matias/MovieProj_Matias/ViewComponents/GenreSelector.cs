using MovieProj_Matias.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieProj_Matias.Models;

namespace MovieProj_Matias.ViewComponents
{
    public class GenreSelectorViewComponent : ViewComponent
    { 
        private readonly CinimaContext db;


        public GenreSelectorViewComponent(CinimaContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? selectedGenre) {

            var genres = await GetGenres();

            return View(genres);
        }

        private Task<List<Genre>> GetGenres() {
            return db.Genres.ToListAsync();
        }
    }
}
