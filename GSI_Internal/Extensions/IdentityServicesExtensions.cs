using System.Text;
using GSI_Internal.Context;
using GSI_Internal.Entites;
using GSI_Internal.Models.Api.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


namespace GSI_Internal.Extensions;

public static class IdentityServicesExtensions
{

    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {

        // Identity service
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 6;
            options.User.RequireUniqueEmail = true;
            
        }).AddEntityFrameworkStores<dbContainer>().AddDefaultUI().AddDefaultTokenProviders(); 

        
           // .AddDefaultTokenProviders();;
          
          services.Configure<IdentityOptions>(options =>
           {
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireUppercase = false;
               options.Password.RequireLowercase = false;
               options.Password.RequiredLength = 2;
           });
         
            
        //- JWT services
        services.Configure<Jwt>(config.GetSection("JWT"));
            
        services.AddAuthentication(options =>
        {
            // options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = config["JWT:Issuer"],
                ValidAudience =config["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]))
            };
        });


            
        return services;

    }
}
