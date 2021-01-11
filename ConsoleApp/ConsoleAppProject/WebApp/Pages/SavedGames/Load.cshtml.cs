using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.SavedGames
{
    public class Load : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public Load(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SavedGame> SavedGamesList { get;set; } = null!;

        public async Task OnGetAsync()
        {
            SavedGamesList = await _context.SavedGames.ToListAsync();
        }
    }
}