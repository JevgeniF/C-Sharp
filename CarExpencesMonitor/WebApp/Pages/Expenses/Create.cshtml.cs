using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Expenses
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)] public int? Id { get; set; }

        [BindProperty] public Expense Expense { get; set; } = default!;

        public IActionResult OnGet()
        {
            if (Id != null)
            {
                ViewData["CarId"] = new SelectList(_context.Cars.Where(c => c.Id == Id), "Id", "Model");
            }
            else
            {
                ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model");
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Expenses.Add(Expense);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new {id = Id});
        }
    }
}