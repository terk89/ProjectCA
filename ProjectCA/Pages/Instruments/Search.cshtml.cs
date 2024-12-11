using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;

namespace ProjectCA.Pages.Instruments
{
    [Authorize]
    public class SearchModel : PageModel
    {
        // Injecting the ApplicationDbContext to interact with the database.
        private readonly ApplicationDbContext _context;

        //injecting dbContext into SearchModel
        public SearchModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Search properties
        public string SearchQuery { get; set; }
        public string SearchField { get; set; } = "All"; // Default to "All"

        // Filtered list of EquipmentItems
        public IList<EquipmentItem> EquipmentItems { get; set; } = new List<EquipmentItem>();

        // Dropdown list for search fields
        public SelectList SearchFields { get; set; }

        // Dropdowns initialization and filter the equipment items based on search parameters
        public async Task OnGetAsync(string searchQuery, string searchField)
        {
            // Initialize dropdown for search fields (All, CatNumber, InstrumentType, Manufacturer)
            SearchFields = new SelectList(new List<string> { "All", "CatNumber", "InstrumentType", "Manufacturer" });

            // Only perform the search if there's a query provided
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var query = _context.EquipmentItems.Include(e => e.Manufacturer).Include(e => e.InstrumentType).AsQueryable();

                // Apply search filter based on selected field
                switch (searchField)
                {
                    case "CatNumber":
                        query = query.Where(e => e.CatNumber.Contains(searchQuery));
                        break;
                    case "InstrumentType":
                        query = query.Where(e => e.InstrumentType.Type.Contains(searchQuery));
                        break;
                    case "Manufacturer":
                        query = query.Where(e => e.Manufacturer.Name.Contains(searchQuery));
                        break;
                    case "All":
                        query = query.Where(e => e.CatNumber.Contains(searchQuery) ||
                                                 e.SerialNumber.Contains(searchQuery) ||
                                                 e.InstrumentType.Type.Contains(searchQuery) ||
                                                 e.Manufacturer.Name.Contains(searchQuery));
                        break;
                }

                // Execute the query and retrieve the filtered list of equipment items
                EquipmentItems = await query.ToListAsync();
            }
        }
    }
}
