using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public double TotalCosts;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)] public int? Id { get; set; }

        [BindProperty(SupportsGet = true)] public string? SearchCar { get; set; }

        [BindProperty(SupportsGet = true)] public string? SearchCost { get; set; }

        [BindProperty(SupportsGet = true)] public string? SearchCategory { get; set; }

        [BindProperty(SupportsGet = true)] public string? Btn { get; set; }

        public IList<Expense> Expense { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IQueryable<Expense> query = _context.Expenses.Include(e => e.Car)
                .Include(e => e.Category);

            if (Btn == "Reset")
            {
                SearchCar = "";
                SearchCost = "";
                SearchCategory = "";
                Btn = "";

                return RedirectToPage("/Expenses/Index");
            }

            SearchCar = SearchCar?.Trim();
            if (!string.IsNullOrWhiteSpace(SearchCar))
            {
                query = query.Where(e => e.Car!.Model.Contains(SearchCar) || e.Car!.RegNumber.Contains(SearchCar));
            }

            SearchCost = SearchCost?.Trim();
            if (!string.IsNullOrWhiteSpace(SearchCost))
            {
                query = query.Where(e => e.Description.Contains(SearchCost));
            }


            if (Id != null && ExpensesExists(Id))
            {
                query = query.Where(e => e.Car!.Id == Id);
            }

            Expense = await query.ToListAsync();

            foreach (var expense in Expense)
            {
                TotalCosts += expense.Price;
            }

            return Page();
        }

        private bool ExpensesExists(int? id)
        {
            return _context.Expenses.Any(e => e.Car!.Id == Id);
        }
    }
}