using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRA.Application.UseCases.Prisoners;
using CSRA.Data;
using CSRA.SingleOffenderId;

namespace CSRA.Application.Integration.UseCases.Prisoners
{
    using Microsoft.EntityFrameworkCore;
    using PrisonerEntity = CSRA.Data.Entities.Prisoner;

    public class PrisonerRepository : IPrisonerRepository
    {
        private readonly CsraContext context;
        private readonly CSRA.SingleOffenderId.ISingleOffenderIdClient soidClient;

        public PrisonerRepository(CsraContext context, CSRA.SingleOffenderId.ISingleOffenderIdClient soidClient)
        {
            this.context = context;
            this.soidClient = soidClient;
        }

        public async Task<IList<Prisoner>> GetPrisonersExpectedToday()
        {
            var prisonerEntityList = await context.Prisoners.Include(p => p.FromLocation).ToListAsync();

            return prisonerEntityList.Select(ConvertFromEntity).ToList();
        }

        public async Task<IList<Prisoner>> SearchNomisIdentities(string surname)
        {
            var identitiesList = await soidClient.SearchIdentities(1, 25, surname);

            return identitiesList.Select(ConvertFromNomisIdentity).ToList();
        }

        private Prisoner ConvertFromEntity(PrisonerEntity entity)
        {
            return new Prisoner
            {
                PrisonerId = entity.PrisonerId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                NomisId = entity.NomisId,
                DateOfBirth = entity.DoB,
                ReceptionDate = entity.ReceptionDate,
                FromLocation = entity.FromLocation?.Name
            };
        }

        private Prisoner ConvertFromNomisIdentity(NomisIdentity entity)
        {
            return new Prisoner
            {
                //PrisonerId = entity.PrisonerId,
                FirstName = entity.GivenName,
                LastName = entity.Surname,
                NomisId = entity.NomsId
            };
        }
    }
}
