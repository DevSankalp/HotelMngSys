using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Pages.Guests
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Guest> Guests { get; set; } = new List<Guest>();

        public async Task OnGetAsync()
        {
            Guests = await _context.Guests
                .OrderBy(g => g.FullName)
                .ToListAsync();
        }
    }
}