using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;
using System.Data;

namespace ProjectCA.Pages.Instruments
{
    //operation restricted to admin
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        //reading the database 
        private readonly ApplicationDbContext _context;
        //injecting dbContext into DeleteModel
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        // binding property to handle form input
        [BindProperty]
        public EquipmentItem EquipmentItem { get; set; } = default!;
        // Handling GET requests for the Delete page.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // check the id selected is null or present in database
            if (id == null || _context.EquipmentItems == null)
            {
                return NotFound();
            }
            //retrieve the EquipmentItem with the given ID
            var equipmentitem = await _context.EquipmentItems.FirstOrDefaultAsync(m => m.EquipmentID == id);

            // If no item is found, return a 404 response.
            if (equipmentitem == null)
            {
                return NotFound();
            }
            // If the item is found, assign it to the EquipmentItem and display.
            else
            {
                EquipmentItem = equipmentitem;
            }
            return Page();
        }
        // handling POST requests to confirm and delete the EquipmentItem.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // check the id selected is null or present in database
            if (id == null || _context.EquipmentItems == null)
            {
                return NotFound();
            }
            //retrieve the EquipmentItem with the given ID
            var equipmentitem = await _context.EquipmentItems.FindAsync(id);

            // If the item is found, assign it to the EquipmentItem and delete.
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
