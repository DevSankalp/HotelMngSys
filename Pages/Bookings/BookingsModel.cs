using System.Collections.Generic;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Bookings
{
    public class BookingsModel : PageModel
    {
        public List<Booking> Bookings { get; set; } = new();

        public void OnGet()
        {
            // TODO: retrieve bookings from database or service
        }
    }
}
