using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Data.DataModels
{
    public class Prisoner
    {
        public int PrisonerID { get; set; }
        public string LastName { get; set; }
        public string Firstname { get; set; }
        public DateTime ReceptionDate { get; set; }

        public string NomisId { get; set; }

        public DateTime DoB { get; set; }

        public virtual Location FromLocation { get; set; }
    }
}
