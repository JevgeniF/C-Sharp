using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Marks
{
    public class CreateFmEdit : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateFmEdit(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public Mark Mark { get; set; } = default!;
        [BindProperty(SupportsGet = true)] public int? Id { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_context.Marks.Any(m => m.Name == Mark.Name))
            {
                ModelState.AddModelError("", "Such Category exists already!");
                return Page();
            }

            _context.Marks.Add(Mark);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Cars/Edit", new {id = Id});
        }
    }
}