using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;

namespace ProjectCA.Pages.Instruments
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Equipment Items to Display
        public IList<EquipmentItem> EquipmentItem { get; set; } = new List<EquipmentItem>();

        // Sorting Parameters
        public string CurrentSort { get; set; }
        public string UserSort { get; set; }
        public string TypeSort { get; set; }
        public string CatNumberSort { get; set; }
        public string CalibrationDueSort { get; set; }
        public string StatusSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // Set sorting parameters
            UserSort = string.IsNullOrEmpty(sortOrder) ? "user_desc" : "";
            TypeSort = sortOrder == "type" ? "type_desc" : "type";
            CatNumberSort = sortOrder == "catnumber" ? "catnumber_desc" : "catnumber";
            CalibrationDueSort = sortOrder == "calibrationdue" ? "calibrationdue_desc" : "calibrationdue";
            StatusSort = sortOrder == "status" ? "status_desc" : "status";

            // Remember current sort order
            CurrentSort = sortOrder;

            // Fetch and sort EquipmentItems
            IQueryable<EquipmentItem> equipmentQuery = _context.EquipmentItems
                .Include(e => e.User)
                .Include(e => e.InstrumentType);

            switch (sortOrder)
            {
                case "user_desc":
                    equipmentQuery = equipmentQuery.OrderByDescending(e => e.User.UserName);
                    break;
                case "type":
                    equipmentQuery = equipmentQuery.OrderBy(e => e.InstrumentType.Type);
                    break;
                case "type_desc":
                    equipmentQuery = equipmentQuery.OrderByDescending(e => e.InstrumentType.Type);
                    break;
                case "catnumber":
                    equipmentQuery = equipmentQuery.OrderBy(e => e.CatNumber);
                    break;
                case "catnumber_desc":
                    equipmentQuery = equipmentQuery.OrderByDescending(e => e.CatNumber);
                    break;
                case "calibrationdue":
                    equipmentQuery = equipmentQuery.OrderBy(e => e.CalibrationDue);
                    break;
                case "calibrationdue_desc":
                    equipmentQuery = equipmentQuery.OrderByDescending(e => e.CalibrationDue);
                    break;
                case "status":
                    equipmentQuery = equipmentQuery.OrderBy(e => e.Status);
                    break;
                case "status_desc":
                    equipmentQuery = equipmentQuery.OrderByDescending(e => e.Status);
                    break;
                default:
                    equipmentQuery = equipmentQuery.OrderBy(e => e.User.UserName);
                    break;
            }

            // Execute query
            EquipmentItem = await equipmentQuery.AsNoTracking().ToListAsync();
        }
    }
}
