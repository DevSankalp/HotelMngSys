using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Billing
{
    public class CreateInvoiceModel : PageModel
    {
        [BindProperty]
        public Invoice Invoice { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // TODO: persist invoice
            return RedirectToPage("Invoice");
        }
    }
}
