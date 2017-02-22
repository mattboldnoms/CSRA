using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Application.UseCases.Prisoners
{
    public interface IPrisonerRepository
    {
        Task<IList<Prisoner>> GetPrisonersExpectedToday();

        Task<IList<Prisoner>> SearchNomisIdentities(string surname);
    }
}
