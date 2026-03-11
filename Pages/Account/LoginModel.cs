using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        public bool LoginFailed { get; set; }

        public void OnGet()
        {
            // display login form
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                LoginFailed = true;
                return Page();
            }

            // TODO: authenticate user with a real service
            // redirect to dashboard for now
            return RedirectToPage("/Dashboard/Index");
        }
    }
}
