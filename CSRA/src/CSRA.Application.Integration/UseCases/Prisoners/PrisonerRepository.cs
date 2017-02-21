using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRA.Application.UseCases.Prisoners;
using CSRA.Data;

namespace CSRA.Application.Integration.UseCases.Prisoners
{
    using Microsoft.EntityFrameworkCore;
    using PrisonerEntity = CSRA.Data.Entities.Prisoner;

    public class PrisonerRepository : IPrisonerRepository
    {
        private readonly CsraContext context;

        public PrisonerRepository(CsraContext context)
        {
            this.context = context;
        }

        public async Task<IList<Prisoner>> GetPrisonersExpectedToday()
        {
            var prisonerEntityList = await context.Prisoners.Include(p => p.FromLocation).ToListAsync();

            return prisonerEntityList.Select(ConvertFromEntity).ToList();
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
    }
}
