using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DSEDRazor.Data;
using Microsoft.EntityFrameworkCore;

namespace DSEDRazor.Pages
{
    public class MoviesModel : PageModel
    {
        private readonly AppDbContext _db;

        public MoviesModel(AppDbContext db) => _db = db;

        public IList<Movie> Movies {get; private set;}

        public async Task OnGetAsync()
        {
            Movies = await _db.Movies.AsNoTracking().ToListAsync();            
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var movie = await _db.Movies.FindAsync(id);
            if (movie != null){
                _db.Movies.Remove(movie);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
