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
    public class RentalsModel : PageModel
    {
        private readonly AppDbContext _db;

        public RentalsModel(AppDbContext db) => _db = db;

        public IList<RentedMovie> RentedMovies {get; private set;}

        public async Task OnGetAsync()
        {
            RentedMovies = await _db.RentedMovies.AsNoTracking()
            .Include(a => a.Customer)
            .Include(a => a.Movie)
            .ToListAsync();            
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var rental = await _db.RentedMovies.FindAsync(id);
            if (rental != null){
                _db.RentedMovies.Remove(rental);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
