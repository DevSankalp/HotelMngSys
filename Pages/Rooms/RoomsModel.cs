using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Rooms
{
    public class RoomsModel : PageModel
    {
        private readonly HotelDbContext _db;

        public RoomsModel(HotelDbContext db)
        {
            _db = db;
        }

        // the list that will be used by the Razor page
        public List<Room> Rooms { get; set; } = new();

        public void OnGet()
        {
            Rooms = _db.Rooms.ToList();
        }
    }
}
