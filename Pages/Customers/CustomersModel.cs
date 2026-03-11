using System.Collections.Generic;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Customers
{
    public class CustomersModel : PageModel
    {
        public List<Customer> Customers { get; set; } = new();

        public void OnGet()
        {
            // TODO: populate the customer list from a repository or service
        }
    }
}
