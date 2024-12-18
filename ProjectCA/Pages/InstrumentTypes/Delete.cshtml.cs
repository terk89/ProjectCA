using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;
using System.Data;

namespace ProjectCA.Pages.InstrumentTypes
{   
    // Available only for administrator
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        // Injecting the ApplicationDbContext to interact with the database.
        private readonly ApplicationDbContext _context;

        //injecting dbContext into DeleteModel
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InstrumentType InstrumentType { get; set; } = default!;

        // GET InstrumentType
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.InstrumentTypes == null)
            {
                return NotFound();
            }

            var instrumenttype = await _context.InstrumentTypes.FirstOrDefaultAsync(m => m.InstrumentTypeID == id);

            if (instrumenttype == null)
            {
                return NotFound();
            }
            else
            {
                InstrumentType = instrumenttype;
            }
            return Page();
        }
        // POST Delete Instrument Type if InstrumentType present in Database
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.InstrumentTypes == null)
            {
                return NotFound();
            }
            var instrumenttype = await _context.InstrumentTypes.FindAsync(id);

            if (instrumenttype != null)
            {
                InstrumentType = instrumenttype;
                _context.InstrumentTypes.Remove(InstrumentType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
