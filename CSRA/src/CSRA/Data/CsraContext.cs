using CSRA.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CSRA.Data
{
    public class CsraContext : DbContext
    {
        public CsraContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Prisoner> Prisoners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        }
    }
}
