using Microsoft.EntityFrameworkCore;
using CSRA.DAL.Models;

namespace CSRA.DAL
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
