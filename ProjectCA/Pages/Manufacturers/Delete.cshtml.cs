using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;
using System.Data;

namespace ProjectCA.Pages.Manufacturers
{
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.ManufacturerID == id);

            if (manufacturer == null)
            {
                return NotFound();
            }
            else
            {
                Manufacturer = manufacturer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer != null)
            {
                Manufacturer = manufacturer;
                _context.Manufacturers.Remove(Manufacturer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
