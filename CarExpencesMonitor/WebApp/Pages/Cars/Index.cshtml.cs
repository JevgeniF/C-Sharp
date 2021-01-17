using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Cars
                .Include(c => c.BodyStyle)
                .Include(c => c.FuelType)
                .Include(c => c.Mark)
                .Include(c => c.Transmission).ToListAsync();
        }
    }
}