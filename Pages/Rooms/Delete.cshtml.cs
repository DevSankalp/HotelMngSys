using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Pages.Rooms
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Room = await _context.Rooms.FindAsync(id);

            if (Room == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var hasBookings = await _context.Bookings.AnyAsync(b => b.RoomId == Room.Id);

            if (hasBookings)
            {
                ModelState.AddModelError(
                    "",
                    "This room cannot be deleted because it has bookings."
                );
                return Page();
            }

            var room = await _context.Rooms.FindAsync(Room.Id);

            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
