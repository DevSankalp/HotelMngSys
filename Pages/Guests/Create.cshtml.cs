using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Pages.Guests
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guest Guest { get; set; }

        public void OnGet()
        {
        }


public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var guestExists = await _context.Guests
            .AnyAsync(g =>
                g.FullName == Guest.FullName &&
                g.Phone == Guest.Phone &&
                g.Email == Guest.Email &&
                g.Address == Guest.Address);

        if (guestExists)
        {
            ModelState.AddModelError("", "This guest already exists in the system.");
            return Page();
        }

        _context.Guests.Add(Guest);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
}