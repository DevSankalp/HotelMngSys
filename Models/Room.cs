using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public int RoomTypeId { get; set; }

        [ValidateNever]
        public RoomType? RoomType { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; } = "Available";
    }
}