using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public SelectList Guests { get; set; }
        public SelectList Rooms { get; set; }

        private void LoadDropdowns()
        {
            Guests = new SelectList(_context.Guests, "Id", "FullName", Booking.GuestId);
            Rooms = new SelectList(_context.Rooms, "Id", "RoomNumber", Booking.RoomId);
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Booking = await _context.Bookings.FindAsync(id);

            if (Booking == null)
                return NotFound();

            LoadDropdowns();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return Page();
            }

            if (Booking.CheckOutDate <= Booking.CheckInDate)
            {
                ModelState.AddModelError("Booking.CheckOutDate", "Check-out must be after check-in.");
                LoadDropdowns();
                return Page();
            }

            if (Booking.CheckInDate < DateTime.Today)
            {
                ModelState.AddModelError("Booking.CheckInDate", "Check-in date cannot be in the past.");
                LoadDropdowns();
                return Page();
            }

            var room = await _context.Rooms.FindAsync(Booking.RoomId);

            if (room != null && Booking.CheckOutDate <= DateTime.Today)
            {
                room.Status = "Available";
            }

            var existingBooking = await _context.Bookings.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == Booking.Id);

            if (existingBooking == null)
                return NotFound();

            _context.Attach(Booking).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
