using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectCA.Models;
using ProjectCA.Services;
using System.Data;

namespace ProjectCA.Pages.InstrumentTypes
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "Name");
            return Page();
        }

        [BindProperty]
        public InstrumentType InstrumentType { get; set; } = default!;

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
