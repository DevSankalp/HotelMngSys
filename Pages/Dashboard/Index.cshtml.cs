using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data;

namespace HotelManagementSystem.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
        public int OccupiedRooms { get; set; }
        public int TotalGuests { get; set; }
        public int ActiveBookings { get; set; }
        public decimal TotalRevenue { get; set; }

        public async Task OnGetAsync()
        {
            TotalRooms = await _context.Rooms.CountAsync();

            AvailableRooms = await _context.Rooms
                .CountAsync(r => r.Status == "Available");

            OccupiedRooms = await _context.Rooms
                .CountAsync(r => r.Status == "Occupied");

            TotalGuests = await _context.Guests.CountAsync();

            ActiveBookings = await _context.Bookings
                .CountAsync(b => b.CheckOutDate >= DateTime.Today);

            TotalRevenue = await _context.Payments
                .SumAsync(p => (decimal?)p.Amount) ?? 0;
        }
    }
}