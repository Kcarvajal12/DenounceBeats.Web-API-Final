using Microsoft.EntityFrameworkCore;
using DenounceBeats.Domain.Entities;

namespace DenounceBeats.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sector> Sectors { get; set; }
    }
}