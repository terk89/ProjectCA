using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;

namespace ProjectCA.Pages.InstrumentTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<InstrumentType> InstrumentType { get; set; } = default!;

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
