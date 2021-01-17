using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.BodyStyles
{
    public class CreateFmEdit : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateFmEdit(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public BodyStyle BodyStyle { get; set; } = default!;
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

            if (_context.BodyStyles.Any(b => b.Name == BodyStyle.Name))
            {
                ModelState.AddModelError("", "Such Category exists already!");
                return Page();
            }

            _context.BodyStyles.Add(BodyStyle);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Cars/Edit", new {id = Id});
        }
    }
}