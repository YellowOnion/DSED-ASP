using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DSEDRazor.Data;

namespace DSEDRazor.Pages
{
    public class AddCustomerModel : PageModel
    {
        private readonly AppDbContext _db;

        public AddCustomerModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Customer Customer {get;set;}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

    }
}