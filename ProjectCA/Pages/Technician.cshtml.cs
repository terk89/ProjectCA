using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectCA.Pages
{
    [Authorize(Roles ="tech")]
    public class TechnicianModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
