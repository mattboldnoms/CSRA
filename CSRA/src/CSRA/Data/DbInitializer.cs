using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRA.Data.DataModels;

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

            var prisoners = new Prisoner[]
            {
            new Prisoner{Firstname="Carson",LastName="Alexander", NomisId="1"},
            new Prisoner{Firstname="Billy",LastName="Boggins", NomisId="2"}
            };
            foreach (Prisoner p in prisoners)
            {
                context.Prisoners.Add(p);
            }
            context.SaveChanges();
            
        }
    }
}
