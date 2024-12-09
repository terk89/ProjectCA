using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;

namespace ProjectCA.Pages.InstrumentTypes
{   
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InstrumentType InstrumentType { get; set; } = default!;

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
            InstrumentType = instrumenttype;
            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InstrumentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrumentTypeExists(InstrumentType.InstrumentTypeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InstrumentTypeExists(int id)
        {
            return (_context.InstrumentTypes?.Any(e => e.InstrumentTypeID == id)).GetValueOrDefault();
        }

    }
}
