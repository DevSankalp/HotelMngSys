using System.Collections.Generic;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Billing
{
    public class PaymentModel : PageModel
    {
        public List<Payment> Payments { get; set; } = new();

        public void OnGet()
        {
            // TODO: load payments from database or service
        }
    }
}
