using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CSRA.Application.UseCases.Prisoners;
using CSRA.Application.Integration.UseCases.Prisoners;
using CSRA.SingleOffenderId;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace CSRA
{
    public static class ApplicationDependencyConfig
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<IPrisonerInteractor, PrisonerInteractor>();
            services.AddScoped<IPrisonerRepository, PrisonerRepository>();

            services.AddSingleton<HttpClient>();
            services.AddSingleton<ISingleOffenderIdTokenStore, InMemorySingleOffenderIdTokenStore>();
            services.AddScoped<IBaseClient, BaseClient>(x => 
                new BaseClient(x.GetService<HttpClient>(), configuration["ClientSettings:SingleOffenderId:BaseUri"], configuration["ClientSettings:SingleOffenderId:ClientId"], configuration["ClientSettings:SingleOffenderId:ClientSecret"], x.GetService<ISingleOffenderIdTokenStore>()));
            services.AddScoped<ISingleOffenderIdClient, SingleOffenderIdClient>();
        }
    }
}
