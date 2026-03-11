using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Roles
{
    public class RolesModel : PageModel
    {
        private readonly HotelDbContext _db;

        public RolesModel(HotelDbContext db)
        {
            _db = db;
        }

        public List<Role> Roles { get; set; } = new();

        public void OnGet()
        {
            Roles = _db.Roles.ToList();
        }
    }
}
