using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectCA.Models;
using ProjectCA.Services;
using System.Data;

namespace ProjectCA.Pages.Manufacturers
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Manufacturers == null || Manufacturer == null)
            {
                return Page();
            }

            _context.Manufacturers.Add(Manufacturer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
