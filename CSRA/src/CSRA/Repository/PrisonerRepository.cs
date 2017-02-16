using CSRA.Data;
using CSRA.Data.DataModels;
using CSRA.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Repository
{
    public class PrisonerRepository : CsraRepository<Prisoner>, IPrisonerRepository
    {
        private CsraContext context;

        public PrisonerRepository(CsraContext dbContext)
            : base(dbContext)
        {
            this.context = dbContext;
        }

        public List<Prisoner> GetAllPrisoners()
        {
            return context.Prisoners.Include(p => p.FromLocation).ToList();
        }
    }
}
