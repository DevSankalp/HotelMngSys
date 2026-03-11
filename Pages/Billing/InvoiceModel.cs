using System.Collections.Generic;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Billing
{
    public class InvoiceModel : PageModel
    {
        public List<Invoice> Invoices { get; set; } = new();

        public void OnGet()
        {
            // TODO: load invoices from database or service
        }
    }
}
