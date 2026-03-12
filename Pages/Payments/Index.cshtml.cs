using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Payment> Payments { get; set; }

        public async Task OnGetAsync()
        {
            Payments = await _context
                .Payments.Include(p => p.Booking)
                    .ThenInclude(b => b.Guest)
                .Include(p => p.Booking.Room)
                .ToListAsync();
        }
    }
}
