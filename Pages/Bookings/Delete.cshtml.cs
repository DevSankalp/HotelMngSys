using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Booking = await _context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Booking == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var booking = await _context.Bookings.FindAsync(Booking.Id);

            if (booking != null)
            {
                var room = await _context.Rooms.FindAsync(booking.RoomId);

                if (room != null)
                {
                    room.Status = "Available";
                }

                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}