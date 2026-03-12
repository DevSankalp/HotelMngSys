using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HotelManagementSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int GuestId { get; set; }

        [ValidateNever]
        public Guest? Guest { get; set; }

        [Required]
        public int RoomId { get; set; }

        [ValidateNever]
        public Room? Room { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        public string Status { get; set; } = "Reserved";
    }
}