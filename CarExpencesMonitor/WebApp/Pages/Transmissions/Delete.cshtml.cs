using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Transmissions
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public Transmission Transmission { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transmission = await _context.Transmissions.FirstOrDefaultAsync(m => m.Id == id);

            if (Transmission == null)
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

            Transmission = await _context.Transmissions.FindAsync(id);

            if (Transmission != null)
            {
                _context.Transmissions.Remove(Transmission);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}