using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Registration
    {
        // Should never be seen in front-end, as it's passed internally.
        [Required(ErrorMessage = "EventId is required")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Your name is required")]
        public string AttendeeName { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}