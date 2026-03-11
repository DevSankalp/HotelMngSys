using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed basic roles
            modelBuilder
                .Entity<Role>()
                .HasData(
                    new Role { RoleId = 1, RoleName = Role.Admin },
                    new Role { RoleId = 2, RoleName = Role.Receptionist },
                    new Role { RoleId = 3, RoleName = Role.User }
                );
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
