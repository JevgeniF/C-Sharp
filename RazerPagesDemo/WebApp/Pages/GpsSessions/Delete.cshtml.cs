using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.GpsSessions
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public DeleteModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GpsSession GpsSession { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GpsSession = await _context.GpsSessions.FirstOrDefaultAsync(m => m.GpsSessionId == id);

            if (GpsSession == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GpsSession = await _context.GpsSessions.FindAsync(id);

            if (GpsSession != null)
            {
                _context.GpsSessions.Remove(GpsSession);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
