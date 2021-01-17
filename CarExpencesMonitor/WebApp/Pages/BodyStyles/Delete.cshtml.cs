using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.BodyStyles
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public BodyStyle BodyStyle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BodyStyle = await _context.BodyStyles.FirstOrDefaultAsync(m => m.Id == id);

            if (BodyStyle == null)
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

            BodyStyle = await _context.BodyStyles.FindAsync(id);

            if (BodyStyle != null)
            {
                _context.BodyStyles.Remove(BodyStyle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}