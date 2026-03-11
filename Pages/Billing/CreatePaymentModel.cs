using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Billing
{
    public class CreatePaymentModel : PageModel
    {
        [BindProperty]
        public Payment Payment { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // TODO: persist payment
            return RedirectToPage("Payment");
        }
    }
}
