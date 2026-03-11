using System.Linq;
using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelManagementSystem.Pages.Roles
{
    public class CreateRoleModel : PageModel
    {
        private readonly HotelDbContext _db;

        public CreateRoleModel(HotelDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Role Role { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // restrict to defined names
            var allowed = new[] { Role.Admin, Role.Receptionist, Role.User };
            if (!allowed.Contains(Role.RoleName))
            {
                ModelState.AddModelError(
                    "Role.RoleName",
                    "Role must be one of the predefined types."
                );
                return Page();
            }

            // avoid duplicates: role names are unique
            if (_db.Roles.Any(r => r.RoleName == Role.RoleName))
            {
                ModelState.AddModelError("Role.RoleName", "That role already exists.");
                return Page();
            }

            _db.Roles.Add(Role);
            _db.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
