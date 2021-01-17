using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public string Link = "./Index";

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public Car Car { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["BodyStyleId"] = new SelectList(_context.BodyStyles, "Id", "Name");
            ViewData["FuelTypeId"] = new SelectList(_context.FuelTypes, "Id", "Name");
            ViewData["MarkId"] = new SelectList(_context.Marks, "Id", "Name");
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "Id", "Name");
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();
            return RedirectToPage(Link);
        }
    }
}