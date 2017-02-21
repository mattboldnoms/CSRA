using CSRA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CsraContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Prisoners.Any())
            {
                return;   // DB has been seeded
            }

            var prisoners = new[]
            {
                new Prisoner { FirstName = "Carson", LastName = "Alexander", NomisId="1" },
                new Prisoner { FirstName = "Billy", LastName = "Boggins", NomisId="2" }
            };

            context.Prisoners.AddRange(prisoners);

            context.SaveChanges();
            
        }
    }
}
