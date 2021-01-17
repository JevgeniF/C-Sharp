using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.FuelTypes
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public FuelType FuelType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FuelType = await _context.FuelTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (FuelType == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FuelType = await _context.FuelTypes.FindAsync(id);

            if (FuelType != null)
            {
                _context.FuelTypes.Remove(FuelType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}