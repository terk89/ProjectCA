using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;

namespace ProjectCA.Pages.Manufacturers
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _context.Manufacturers
    .Include(m => m.EquipmentItems) // Include EquipmentItems related to Manufacturer
        .ThenInclude(e => e.InstrumentType) // Include InstrumentType related to each EquipmentItem
    .FirstOrDefaultAsync(m => m.ManufacturerID == id);

            if (Manufacturer == null)
            {
                return NotFound();
            }


            return Page();
        }
    }
}
