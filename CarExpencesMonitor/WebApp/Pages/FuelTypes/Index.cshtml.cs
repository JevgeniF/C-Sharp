using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.FuelTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FuelType> FuelType { get; set; } = default!;

        public async Task OnGetAsync()
        {
            FuelType = await _context.FuelTypes.ToListAsync();
        }
    }
}