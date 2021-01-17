using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; } = default!;
        public IList<Expense> Expense { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Cars
                .Include(c => c.BodyStyle)
                .Include(c => c.FuelType)
                .Include(c => c.Mark)
                .Include(c => c.Transmission)
                .OrderByDescending(c => c.Id).Take(4)
                .ToListAsync();

            Expense = await _context.Expenses
                .Include(e => e.Car)
                .Include(e => e.Category)
                .OrderByDescending(e => e.Id).Take(4)
                .ToListAsync();
        }
    }
}