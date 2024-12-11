using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;
using System.IO;
using System.Text;

namespace ProjectCA.Pages.Instruments
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        // accessing database and IWebHostEnvironment
        public DetailsModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        // properties
        public EquipmentItem EquipmentItem { get; set; } = default!;
        public List<CalibrationRecord> CalibrationRecords { get; set; }

        [BindProperty]
        public CalibrationRecordDto NewCalibrationRecord { get; set; } = new CalibrationRecordDto();

        // Handling GET requests for the Details page.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EquipmentItems == null)
            {
                return NotFound();
            }

            // Loading Equipment Item
            var equipmentitem = await _context.EquipmentItems
                .Include(e => e.User)
                .Include(e => e.InstrumentType)
                .Include(e => e.Manufacturer)
                .FirstOrDefaultAsync(e => e.EquipmentID == id);

            if (equipmentitem == null)
            {
                return NotFound();
            }

            EquipmentItem = equipmentitem;

            // Load and sort Calibration Records
            CalibrationRecords = await _context.CalibrationRecords
                .Where(c => c.EquipmentID == id)
                .Include(c => c.User) // Ensure user details are included
                .OrderByDescending(c => c.CalibrationDate) // Sort by CalibrationDate descending
                .ToListAsync();

            ViewData["Users"] = _context.Users
                .Select(u => new SelectListItem { Value = u.Id, Text = u.FullName })
                .ToList();

            return Page();
        }

        // handling POST request for new Calibration Record
        public async Task<IActionResult> OnPostAsync(int id)
        {
            // Check if the model is valid and if the calibration certificate is provided
            if (!ModelState.IsValid || NewCalibrationRecord.CalibrationCert == null)
            {
                ModelState.AddModelError("CalibrationCert", "Calibration certificate is required.");
                return await OnGetAsync(id);
            }

            // File Handling - Get file data as byte array
            using (var memoryStream = new MemoryStream())
            {
                await NewCalibrationRecord.CalibrationCert.CopyToAsync(memoryStream); // Copy the file content to memory stream
                var fileBytes = memoryStream.ToArray(); // Convert memory stream to byte array

                // Create a new CalibrationRecord object to store the calibration data
                var calibrationRecord = new CalibrationRecord
                {
                    CalibrationDate = NewCalibrationRecord.CalibrationDate,
                    UserID = NewCalibrationRecord.UserID,
                    EquipmentID = id,
                    CalibrationCert = fileBytes // Save the byte array of the file content
                };

                // Add the new CalibrationRecord to the database
                _context.CalibrationRecords.Add(calibrationRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Details", new { id = id });
        }


        public async Task<IActionResult> OnGetDownloadCalibrationCertificateAsync(int id)
        {
            // Fetch the calibration record by its ID
            var record = await _context.CalibrationRecords.FindAsync(id);

            if (record == null || record.CalibrationCert == null)
            {
                return NotFound(); // If the record or the certificate is missing, return NotFound
            }

            // Return the PDF file from the database (byte array)
            return File(record.CalibrationCert, "application/pdf", $"CalibrationCert_{record.CalibrationRecordID}.pdf");
        }

        public async Task<IActionResult> OnPostDeleteCalibrationRecordAsync(int id)
        {
            // Check if the user is an admin
            if (!User.IsInRole("admin"))
            {
                return Forbid(); // Return a 403 Forbidden if the user isn't an admin
            }

            var calibrationRecord = await _context.CalibrationRecords.FindAsync(id);

            if (calibrationRecord == null)
            {
                return NotFound();
            }

            _context.CalibrationRecords.Remove(calibrationRecord);
            await _context.SaveChangesAsync();

            // Redirect back to the details page after deletion
            return RedirectToPage("./Details", new { id = calibrationRecord.EquipmentID });
        }
    }
}
