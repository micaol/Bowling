using Microsoft.EntityFrameworkCore;

namespace Bowling.Models
{
    public class BowlingContext: DbContext
    {
        public BowlingContext(DbContextOptions<BowlingContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
    }
}