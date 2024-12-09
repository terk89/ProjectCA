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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public DetailsModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public EquipmentItem EquipmentItem { get; set; } = default!;
        public List<CalibrationRecord> CalibrationRecords { get; set; }

        [BindProperty]
        public CalibrationRecordDto NewCalibrationRecord { get; set; } = new CalibrationRecordDto();

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


        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid || NewCalibrationRecord.CalibrationCert == null)
            {
                ModelState.AddModelError("CalibrationCert", "Calibration certificate is required.");
                return await OnGetAsync(id);
            }

            // File Handling
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(NewCalibrationRecord.CalibrationCert.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await NewCalibrationRecord.CalibrationCert.CopyToAsync(fileStream);
            }

            var calibrationRecord = new CalibrationRecord
            {
                CalibrationDate = NewCalibrationRecord.CalibrationDate,
                UserID = NewCalibrationRecord.UserID,
                EquipmentID = id,
                CalibrationCert = Encoding.UTF8.GetBytes(filePath) // Save the file path in the database
            };

            _context.CalibrationRecords.Add(calibrationRecord);
            await _context.SaveChangesAsync();

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
