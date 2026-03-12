using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Room> Rooms { get; set; }

        public async Task OnGetAsync()
        {
            // 1. Free expired rooms
            var roomsToUpdate = await _context
                .Bookings.Where(b => b.CheckOutDate < DateTime.Today)
                .Select(b => b.Room)
                .Where(r => r.Status == "Occupied")
                .ToListAsync();

            foreach (var room in roomsToUpdate)
                room.Status = "Available";

            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();

            Rooms = await _context.Rooms.Include(r => r.RoomType).ToListAsync();
        }
    }
}
