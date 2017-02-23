using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Application.UseCases.Prisoners
{
    public class SearchNomisIdentitiesResponse
    {
        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime Dob { get; set; }

        public string NomisId { get; set; }

        public IList<Prisoner> SearchResults { get; set; } = new List<Prisoner>();
    }
}
