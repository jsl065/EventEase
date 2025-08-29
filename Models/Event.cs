namespace EventEase.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Location { get; set; } = String.Empty;

        public DateOnly Date { get; set; }

        public int AvailableSpots { get; set; }
    }
}