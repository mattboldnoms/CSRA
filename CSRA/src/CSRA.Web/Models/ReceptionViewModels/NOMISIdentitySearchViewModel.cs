using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Models.ReceptionViewModels
{
    public class NOMISIdentitySearchViewModel
    {
        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime Dob { get; set; }

        public string NomisId { get; set; }

        public IEnumerable<CSRA.Application.UseCases.Prisoners.Prisoner> SearchResults { get; set; }
    }
}
