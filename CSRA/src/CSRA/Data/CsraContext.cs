using CSRA.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CSRA.Data
{
    public class CsraContext : DbContext
    {
        public CsraContext() : base()
        {
        }

        public DbSet<Prisoner> Prisoners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        }
    }
}
