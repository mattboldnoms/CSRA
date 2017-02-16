using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRA.Data.DataModels;

namespace CSRA.Services.IServices
{
    public interface IPrisonerService
    {
        IList<Prisoner> GetAllPrisoners();
    }
}
