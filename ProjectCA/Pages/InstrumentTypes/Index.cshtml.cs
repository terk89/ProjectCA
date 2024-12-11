using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;

namespace ProjectCA.Pages.InstrumentTypes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        // Injecting the ApplicationDbContext to interact with the database.
        private readonly ApplicationDbContext _context;

        //injecting dbContext into IndexModel
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<InstrumentType> InstrumentType { get; set; } = default!;

        //GET Instrument Types from database
        public async Task OnGetAsync()
        {
            if (_context.InstrumentTypes != null)
            {
                InstrumentType = await _context.InstrumentTypes
                .ToListAsync();
            }
        }
    }
}
