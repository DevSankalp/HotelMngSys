namespace HotelManagementSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public string? RoomNumber { get; set; }

        public int RoomTypeId { get; set; }

        public string? TypeName { get; set; }

        public decimal Price { get; set; }

        public string? Status { get; set; }
    }
}
