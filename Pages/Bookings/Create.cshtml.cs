using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private void LoadDropdowns()
        {
            Guests = new SelectList(_context.Guests, "Id", "FullName");
            Rooms = new SelectList(_context.Rooms, "Id", "RoomNumber");
        }

        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public SelectList Guests { get; set; }
        public SelectList Rooms { get; set; }

        public void OnGet()
        {
            LoadDropdowns();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return Page();
            }

            var roomConflict = await _context.Bookings.AnyAsync(b =>
                b.RoomId == Booking.RoomId
                && Booking.CheckInDate < b.CheckOutDate
                && Booking.CheckOutDate > b.CheckInDate
            );

            if (roomConflict)
            {
                ModelState.AddModelError("", "This room is already booked for the selected dates.");

                LoadDropdowns();
                return Page();
            }

            if (Booking.CheckOutDate <= Booking.CheckInDate)
            {
                ModelState.AddModelError("", "Check-out must be after check-in.");
                LoadDropdowns();
                return Page();
            }

            if (Booking.CheckInDate < DateTime.Today)
            {
                ModelState.AddModelError("", "Check-in date cannot be in the past.");
                LoadDropdowns();
                return Page();
            }

            var room = await _context.Rooms.FindAsync(Booking.RoomId);

            if (room.Status == "Maintenance")
            {
                ModelState.AddModelError("", "This room is under maintenance and cannot be booked.");

                LoadDropdowns();
                return Page();
            }

            if (room != null)
                room.Status = "Occupied";

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
