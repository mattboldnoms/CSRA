using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.Application.UseCases.Prisoners
{
    public class PrisonerInteractor : IPrisonerInteractor
    {
        private readonly IPrisonerRepository prisonerRepository;

        public PrisonerInteractor(IPrisonerRepository prisonerRepository)
        {
            this.prisonerRepository = prisonerRepository;
        }

        public async Task<GetPrisonersExpectedTodayResponse> GetPrisonersExpectedToday()
        {
            var response = new GetPrisonersExpectedTodayResponse();

            var prisoners = await this.prisonerRepository.GetPrisonersExpectedToday();

            foreach (var prisoner in prisoners)
            {
                response.Prisoners.Add(prisoner);
            }

            return response;
        }
    }
}
