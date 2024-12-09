using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;

namespace ProjectCA.Pages.InstrumentTypes
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public InstrumentType InstrumentType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.InstrumentTypes == null)
            {
                return NotFound();
            }

            // Fetch the InstrumentType and its associated EquipmentItems
            InstrumentType = await _context.InstrumentTypes
                .Include(it => it.EquipmentItems) // Include related EquipmentItems
                .FirstOrDefaultAsync(it => it.InstrumentTypeID == id);

            if (InstrumentType == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
