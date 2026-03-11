using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        // navigation
        public ICollection<User>? Users { get; set; }

        // pre-defined role names for convenience
        public const string Admin = "Admin"; // full access
        public const string Receptionist = "Receptionist"; // create & edit
        public const string User = "User"; // create & edit
    }
}
