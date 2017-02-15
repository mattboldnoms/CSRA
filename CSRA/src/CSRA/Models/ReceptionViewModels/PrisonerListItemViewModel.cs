using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Models.ReceptionViewModels
{
    public class PrisonerListItemViewModel
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string NomisId { get; set; }

        public DateTime DoB { get; set; }

        public string FromLocation { get; set; }
    }
}
