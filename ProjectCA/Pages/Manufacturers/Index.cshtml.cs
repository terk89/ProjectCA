using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectCA.Models;
using ProjectCA.Services;

namespace ProjectCA.Pages.Manufacturers
{
    [Authorize]
    public class IndexModel : PageModel
        {
            private readonly ApplicationDbContext _context;

            public IndexModel(ApplicationDbContext context)
            {
                _context = context;
            }

            public IList<Manufacturer> Manufacturer { get; set; } = default!;

            public async Task OnGetAsync()
            {
                if (_context.Manufacturers != null)
                {
                    Manufacturer = await _context.Manufacturers.ToListAsync();
                }
            }
        }
    
}
