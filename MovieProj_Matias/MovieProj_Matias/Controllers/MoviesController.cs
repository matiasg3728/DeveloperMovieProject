using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieProj_Matias.Data;
using MovieProj_Matias.Models;

namespace MovieProj_Matias.Controllers
{
    public class MoviesController : Controller
    {
        private readonly CinimaContext _context;

        public MoviesController(CinimaContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }


        /*
            GET: Movies of a certain genre         
         */
        public async Task<IActionResult> MovieGroup(int? genreID) {

          
            return View();
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }




            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            var mID = movie.GenreID;


            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.ID == mID);

            MovieDetailsViewModel mDetailsModel = new MovieDetailsViewModel();
            mDetailsModel.Movie = movie;
            mDetailsModel.Genre = genre;

            return View(mDetailsModel);

            /*
                Im still pretty unsure about what exactly the '=>' operator means but it may be similar function to 'this'

                Here is an example i saw on the internet...

                    var departments = _context.Departments.Include(d => d.Courses);

                    the Include() function is used when you are pulling together related data (creates a join query).
                    Notice that it is used and within its params it looks like that statement is basically declaring a 
                    variable to represent the 'Departments' then specifying what 'thing' in departments you want.

                    Just some thoughts
            */

            // 3/20/18 10:21pm today is monumental. I just realized I can access the ID property from the frickin obj i pulled from my db. Astounding it took me practically 2 weeks

            // 3/20/18 10:27pm HOW THE FUCK DO I RETURN 2 FICKIN MODELSSSSSSSSSSSSSS i knew this would happen to me. Taking a quick break to calm down

            // you bastard im hot on your trail. I found some answers online and I will use them! First up to bat... View Model
            // Im doing this because the article i read said that View models are "Strongly Typed" which i think is a good rule of thumb (If i remember that correctly)
            // I assume its a good idea to go with something strongly typed because it leaves less room for error. It only takes what is defined in its class so everything that 
            // it does is expected. At least that is the logic I will go with. What do you think person reading this? Also im def commiting this before I mess everything up. Not that Im 
            // very far :Shrug:
            
            // 3/20/19 11:30pm
            // Im back, and as you can obviously tell, i won. View model = Great success
            // I honestly got so excited I ran around my house 2 times and im still #pumped.
            // I guess the next logical step is to update the index page to look lit afffff. Then we can do whatever else idc.
            // Id like to thank my mother, and my father, and microsoft, and of course my cat.
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Year,GenreID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Year,GenreID")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }
    }
}
