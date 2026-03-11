namespace HotelManagementSystem.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string? TypeName { get; set; }
        public decimal Price { get; set; }

        // navigation
        public ICollection<Room>? Rooms { get; set; }
    }
}
