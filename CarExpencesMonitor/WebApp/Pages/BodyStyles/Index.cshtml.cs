using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.BodyStyles
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BodyStyle> BodyStyle { get; set; } = default!;

        public async Task OnGetAsync()
        {
            BodyStyle = await _context.BodyStyles.ToListAsync();
        }
    }
}