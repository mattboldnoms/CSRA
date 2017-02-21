using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CSRA.Application.UseCases.Prisoners;
using CSRA.Application.Integration.UseCases.Prisoners;

namespace CSRA
{
    public static class ApplicationDependencyConfig
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPrisonerInteractor, PrisonerInteractor>();
            services.AddScoped<IPrisonerRepository, PrisonerRepository>();
        }
    }
}
