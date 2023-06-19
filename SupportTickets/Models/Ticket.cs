using System.ComponentModel.DataAnnotations;

namespace SupportTickets.Models
{
    public class Ticket
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(90)]
        public string Theme { get; set; }
        public string Text { get; set; }
    }
}
