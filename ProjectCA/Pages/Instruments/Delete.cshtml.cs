using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;
using System.Data;

namespace ProjectCA.Pages.Instruments
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
        public EquipmentItem EquipmentItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EquipmentItems == null)
            {
                return NotFound();
            }

            var equipmentitem = await _context.EquipmentItems.FirstOrDefaultAsync(m => m.EquipmentID == id);

            if (equipmentitem == null)
            {
                return NotFound();
            }
            else
            {
                EquipmentItem = equipmentitem;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EquipmentItems == null)
            {
                return NotFound();
            }
            var equipmentitem = await _context.EquipmentItems.FindAsync(id);

            if (equipmentitem != null)
            {
                EquipmentItem = equipmentitem;
                _context.EquipmentItems.Remove(EquipmentItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
