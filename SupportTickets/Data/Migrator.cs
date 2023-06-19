using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace SupportTickets.Data
{
    public class Migrator : IDesignTimeDbContextFactory<TicketDBContext>
    {
        public TicketDBContext CreateDbContext(string[] args)
        {
            var factory = new DbContextOptionsBuilder<TicketDBContext>();
            factory.UseNpgsql("User ID = postgres; Password = 1namQfeg1; Host = localhost; Port = 5432; Database = tickets_db;");
            var context = new TicketDBContext(factory.Options);
            return context;
        }
    }
}
