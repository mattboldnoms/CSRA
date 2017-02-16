using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSRA.Repository;
using CSRA.Services.IServices;
using CSRA.Data.DataModels;
using CSRA.Repository.IRepository;

namespace CSRA.Services
{
    public class PrisonerService : IPrisonerService
    {
        private IPrisonerRepository prisonerRepo;

        public PrisonerService(IPrisonerRepository prisonerRepository)
        {
            this.prisonerRepo = prisonerRepository;
        }

        public IList<Prisoner> GetAllPrisoners()
        {
            return prisonerRepo.GetAllPrisoners();
        }
    }
}
