using GSI_Internal.Models.Api.Helpers;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using Halat.BusinessLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSI_Internal.Extensions;

public static class ExternalLoginServicesExtensions
{

    public static IServiceCollection AddExternalLoginServices(this IServiceCollection services, IConfiguration config)
    {

        //- GoogleAuthSettings  services
        services.Configure<GoogleAuthSettings>(config.GetSection("GoogleAuthSettings"));
        
        //- GoogleAuthSettings  services
        services.Configure<FacebookAuthSettings>(config.GetSection("FacebookAuthSettings"));

        services.AddScoped<IExternalLoginService, ExternalLoginService>();



        return services;

    }
}
