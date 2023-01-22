using System;
using System.Text.Json.Serialization;
using GSI_Internal.Configuration;
using GSI_Internal.Context;
using GSI_Internal.EmailServices;
using GSI_Internal.Filters;
using GSI_Internal.Repositry.ApiRepositry.Repositories;
using GSI_Internal.Repositry.RequestActionRepo;
using GSI_Internal.Repositry.RequestData_Repo;
using GSI_Internal.Repositry.SlideShowRepo;
using GSI_Internal.Repositry.TaskDocuments;
using GSI_Internal.Repositry.TaskProcessingRepo;
using GSI_Internal.Repositry.TaskRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GSI_Internal.Extensions;

public static class ContextServicesExtensions
{
    public static IServiceCollection AddContextServices(this IServiceCollection services, IConfiguration config)
    {

        //- context && json services
        services.AddDbContext<dbContainer>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));//,b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)).UseLazyLoadingProxies());
        services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        // IBaseRepository && IUnitOfWork Service
        //services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>)); // only Repository
        services.AddTransient<IUnitOfWork, UnitOfWork>(); // Repository and UnitOfWork


        services.Configure<MailSettings>(config.GetSection("MailSettings"));

        //------------------------------------------------------------------------------------------------------------------
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

        services.AddScoped<ITaskRepo, TaskRepo>();
        services.AddScoped<ITaskDocument_Repo, TaskDocument_Repo>();
        services.AddScoped<ITaskProcessingRepo, TaskProcessingRepo>();
        services.AddScoped<IRequest_DataRepo, Request_DataRepo>();
        services.AddScoped<IReequstRepo, ReequstRepo>();



        services.AddScoped<ISlideShowRepo, SlideShowRepo>();
       
        services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.Zero;
        });

        //----------------------------------------------------------------------------------------------------------------------
        return services;
    }
       
}
