using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Pages.Payments
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Payment Payment { get; set; }

        public SelectList Bookings { get; set; }

        public void OnGet()
        {
            var bookings = _context
                .Bookings.Include(b => b.Guest)
                .Include(b => b.Room)
                .ToList()
                .Select(b => new
                {
                    Id = b.Id,
                    Display = b.Guest.FullName + " - Room " + b.Room.RoomNumber,
                });

            Bookings = new SelectList(bookings, "Id", "Display");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var booking = await _context
                .Bookings.Include(b => b.Room)
                .FirstOrDefaultAsync(b => b.Id == Payment.BookingId);

            if (booking == null)
            {
                ModelState.AddModelError("", "Invalid booking selected.");
            }
            else
            {
                Payment.Amount = booking.Room.Price;
                Payment.PaymentDate = DateTime.Now;

                // remove validation error caused by missing Amount in form
                ModelState.Remove("Payment.Amount");
            }

            var paymentExists = await _context.Payments.AnyAsync(p =>
                p.BookingId == Payment.BookingId
            );

            if (paymentExists)
            {
                ModelState.AddModelError("", "Payment already exists for this booking.");
            }

            if (!ModelState.IsValid)
            {
                var bookings = _context
                    .Bookings.Include(b => b.Guest)
                    .Include(b => b.Room)
                    .ToList()
                    .Select(b => new
                    {
                        Id = b.Id,
                        Display = b.Guest.FullName + " - Room " + b.Room.RoomNumber,
                    });

                Bookings = new SelectList(bookings, "Id", "Display");

                return Page();
            }

            _context.Payments.Add(Payment);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
