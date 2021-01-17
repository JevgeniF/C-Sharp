using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.FuelTypes
{
    public class CreateFmCars : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateFmCars(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public FuelType FuelType { get; set; } = default!;

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

            if (_context.FuelTypes.Any(f => f.Name == FuelType.Name))
            {
                ModelState.AddModelError("", "Such Category exists already!");
                return Page();
            }

            _context.FuelTypes.Add(FuelType);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Cars/Create");
        }
    }
}