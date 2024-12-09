using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectCA.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ProjectCA.Pages.Instruments
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EquipmentItem EquipmentItem { get; set; } = new EquipmentItem();

        public async Task<IActionResult> OnGetAsync(int? instrumentTypeId)
        {
            // Populate the ViewData for dropdowns
            ViewData["Id"] = new SelectList(await _context.Users.ToListAsync(), "Id", "FullName");
            ViewData["InstrumentTypeID"] = new SelectList(await _context.InstrumentTypes.ToListAsync(), "InstrumentTypeID", "Type");
            ViewData["Status"] = new SelectList(new[] { "In Service", "Awaiting Calibration", "Damaged", "Lost" });
            ViewData["ManufacturerID"] = new SelectList(await _context.Manufacturers.ToListAsync(), "ManufacturerID", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Id"] = new SelectList(await _context.Users.ToListAsync(), "Id", "FullName");
                ViewData["ManufacturerID"] = new SelectList(await _context.Manufacturers.ToListAsync(), "ManufacturerID", "Name");
                ViewData["InstrumentTypeID"] = new SelectList(await _context.InstrumentTypes.ToListAsync(), "InstrumentTypeID", "Type");
                ViewData["Status"] = new SelectList(new[] { "In Service", "Awaiting Calibration", "Damaged", "Lost" });
                return Page();
            }

            // Add the EquipmentItem to the database
            _context.EquipmentItems.Add(EquipmentItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
