using Microsoft.EntityFrameworkCore;
using SupportTickets.Models;

namespace SupportTickets.Data
{
    public class TicketDBContext : DbContext
    {
        public TicketDBContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
