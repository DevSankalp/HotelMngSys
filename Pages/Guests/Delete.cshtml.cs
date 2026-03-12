using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Pages.Guests
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guest Guest { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Guest = await _context.Guests.FindAsync(id);

            if (Guest == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var hasBookings = await _context.Bookings.AnyAsync(b => b.GuestId == Guest.Id);

            if (hasBookings)
            {
                ModelState.AddModelError("", "Guest cannot be deleted because bookings exist.");
                return Page();
            }

            var guest = await _context.Guests.FindAsync(Guest.Id);

            if (guest != null)
            {
                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
