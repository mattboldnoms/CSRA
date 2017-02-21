using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CSRA.Application.UseCases.Prisoners
{
    public interface IPrisonerInteractor
    {
        Task<GetPrisonersExpectedTodayResponse> GetPrisonersExpectedToday();
    }
}
