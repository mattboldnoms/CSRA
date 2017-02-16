using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRA.Data.DataModels;

namespace CSRA.Repository.IRepository
{
    public interface IPrisonerRepository : IGenericRepository<Prisoner>
    {
        List<Prisoner> GetAllPrisoners();
    }
}
