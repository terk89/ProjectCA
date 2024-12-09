using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;

namespace ProjectCA.Pages.Instruments
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EquipmentItem EquipmentItem { get; set; } = default!;

        // get EquipmentIdem for editing
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EquipmentItems == null)
            {
                return NotFound();
            }

            var equipmentitem = await _context.EquipmentItems
                .Include(e => e.User)
                .Include(e => e.InstrumentType)
                .Include(e => e.Manufacturer)
                .FirstOrDefaultAsync(m => m.EquipmentID == id);

            if (equipmentitem == null)
            {
                return NotFound();
            }
            else
            {
                // repopulate the data
                EquipmentItem = equipmentitem;
                ViewData["UserID"] = new SelectList(_context.Users, "Id", "FullName", EquipmentItem.UserID);
                ViewData["InstrumentTypeID"] = new SelectList(_context.InstrumentTypes, "InstrumentTypeID", "Type", EquipmentItem.InstrumentTypeID);
                ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "Name");
                ViewData["Status"] = new SelectList(new[] { "In Service", "Awaiting Calibration", "Damaged", "Lost" }, EquipmentItem.Status);
            }
            return Page();
        }

        // Update the EquipmentItem
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EquipmentItems == null)
            {
                return NotFound();
            }

            var equipmentitem = await _context.EquipmentItems.FindAsync(id);

            if (equipmentitem == null)
            {
                return NotFound();
            }

            // Update the properties 
            equipmentitem.CatNumber = EquipmentItem.CatNumber;
            equipmentitem.SerialNumber = EquipmentItem.SerialNumber;
            equipmentitem.CalibrationDue = EquipmentItem.CalibrationDue;
            equipmentitem.Status = EquipmentItem.Status;

            // if the UserID or InstrumentTypeID is changed, update
            equipmentitem.UserID = EquipmentItem.UserID;
            equipmentitem.InstrumentTypeID = EquipmentItem.InstrumentTypeID;

            // Save the changes to the database
            _context.EquipmentItems.Update(equipmentitem);
            await _context.SaveChangesAsync();

            // Redirect to the list or details page after successful update
            return RedirectToPage("./Index");
        }
    }
}
