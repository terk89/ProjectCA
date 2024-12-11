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
    // Page available only for administrator
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        //reading the database 
        private readonly ApplicationDbContext _context;

        //injecting dbContext into CreateModel
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        // binding property to handle form input
        [BindProperty]
        public EquipmentItem EquipmentItem { get; set; } = new EquipmentItem();

        // Handling GET requests for the Create page.
        public async Task<IActionResult> OnGetAsync(int? instrumentTypeId)
        {
            // Populate the ViewData for dropdowns
            ViewData["Id"] = new SelectList(await _context.Users.ToListAsync(), "Id", "FullName");
            ViewData["InstrumentTypeID"] = new SelectList(await _context.InstrumentTypes.ToListAsync(), "InstrumentTypeID", "Type");
            ViewData["Status"] = new SelectList(new[] { "In Service", "Awaiting Calibration", "Damaged", "Lost" });
            ViewData["ManufacturerID"] = new SelectList(await _context.Manufacturers.ToListAsync(), "ManufacturerID", "Name");

            return Page();
        }

        // handling POST request for creating a new EquipmentItem
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the ViewData for dropdowns
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
