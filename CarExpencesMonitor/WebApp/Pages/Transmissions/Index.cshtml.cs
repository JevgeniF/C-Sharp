using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Transmissions
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Transmission> Transmission { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Transmission = await _context.Transmissions.ToListAsync();
        }
    }
}