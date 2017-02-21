using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.SingleOffenderId
{
    public class SingleOffenderIdClient : ISingleOffenderIdClient
    {
        private IBaseClient baseClient;
        public SingleOffenderIdClient(IBaseClient baseClient)
        {
            this.baseClient = baseClient;
        }

        public async Task<IEnumerable<Offender>> FindOffenders(int page, int pageSize, string nomsId)
        {
            var uri = $"api/offenders/search?page={page}&per_page={pageSize}&noms_id={nomsId}";
            var offender = await baseClient.Get<IEnumerable<Offender>>(uri);
            return offender;
        }

        public async Task<Offender> GetOffender(string id)
        {
            var uri = $"api/offenders/{id}";
            var offender = await baseClient.Get<Offender>(uri);
            return offender;
        }

        public async Task<IEnumerable<Offender>> GetOffenders(int page, int pageSize, DateTime updatedAfter)
        {
            var uri = $"api/offenders/?page={page}&per_page={pageSize}&updated_after={updatedAfter.ToString("dd/MM/yyyy")}";
            var offenders = await baseClient.Get<IEnumerable<Offender>>(uri);
            return offenders;
        }
    }
}
