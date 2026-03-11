using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Rooms
{
    public class CreateRoomModel : PageModel
    {
        private readonly HotelDbContext _db;

        public CreateRoomModel(HotelDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Room Room { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Rooms.Add(Room);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
