using System;

namespace HotelManagementSystem.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int BookingId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime IssuedDate { get; set; }

        // navigation
        public Booking? Booking { get; set; }
    }
}
