namespace Web.Models
{
    public class ReservationCreateRequest
    {
        public DateTime Date { get; set; }
        public int NumberOfGuests { get; set; }
        public string UserId { get; set; }
        public int ReservationTypeId { get; set; }
        public int RestaurantId { get; set; }
    }
}
