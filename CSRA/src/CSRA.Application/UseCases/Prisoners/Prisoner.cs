using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Application.UseCases.Prisoners
{
    public class Prisoner
    {
        public int PrisonerId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime ReceptionDate { get; set; }

        public string NomisId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FromLocation { get; set; }
    }
}
