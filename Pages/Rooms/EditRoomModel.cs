using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Rooms
{
    public class EditRoomModel : PageModel
    {
        private readonly HotelDbContext _db;

        public EditRoomModel(HotelDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Room Room { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Room = _db.Rooms.FirstOrDefault(r => r.RoomId == id);
            if (Room == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Rooms.Update(Room);
            _db.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
