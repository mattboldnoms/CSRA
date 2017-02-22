using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.SingleOffenderId
{
    public interface ISingleOffenderIdClient
    {
        Task<IEnumerable<Offender>> FindOffenders(int page, int pageSize, string nomsId);

        Task<IEnumerable<Offender>> GetOffenders(int page, int pageSize, DateTime updatedAfter);

        Task<Offender> GetOffender(string id);

        Task<IEnumerable<NomisIdentity>> SearchIdentities(int page, int pageSize, string surname);
    }
}
