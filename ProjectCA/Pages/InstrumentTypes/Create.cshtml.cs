using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectCA.Models;
using ProjectCA.Services;
using System.Data;

namespace ProjectCA.Pages.InstrumentTypes
{
    // Available only for administrator
    [Authorize(Roles = "admin")]

    
    public class CreateModel : PageModel
    {
        // Injecting the ApplicationDbContext to interact with the database.
        private readonly ApplicationDbContext _context;

        //injecting dbContext into CreateModel
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET manufacturers
        public IActionResult OnGet()
        {
            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "Name");
            return Page();
        }

        [BindProperty]
        public InstrumentType InstrumentType { get; set; } = default!;
        //POST adding a new Manufacturer if Modelstate is valid
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.InstrumentTypes == null || InstrumentType == null)
            {
                ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "Name");
                return Page();
            }

            _context.InstrumentTypes.Add(InstrumentType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
