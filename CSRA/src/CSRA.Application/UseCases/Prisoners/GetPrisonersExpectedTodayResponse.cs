using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Application.UseCases.Prisoners
{
    public class GetPrisonersExpectedTodayResponse
    {
        public IList<Prisoner> Prisoners { get; } = new List<Prisoner>(); 
    }
}
