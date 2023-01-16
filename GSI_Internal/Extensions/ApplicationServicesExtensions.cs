using System;
using CorePush.Apple;
using CorePush.Google;
using GSI_Internal.Models.Api.Helpers;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.ApiRepositry.Services;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GSI_Internal.Extensions;

public static class ApplicationServicesExtensions
{
    // interfaces sevices [IAccountService, IPhotoHandling,[ INotificationService, FcmNotificationSetting, FcmSender,ApnSender ], AddAutoMapper, hangfire  ]
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
          

        // Session Service
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromHours(12);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
            
        // Application Service 
        services.AddScoped<IAccountService, AccountService>();
        services.AddTransient<IFileHandling, FileHandling>();
        services.AddTransient<INotificationService, NotificationService>();
        services.Configure<FcmNotificationSetting>(config.GetSection("FcmNotification"));
        services.AddHttpClient<FcmSender>();
        services.AddHttpClient<ApnSender>();
        services.AddAutoMapper(typeof(Program).Assembly);
       
        // Hangfire Service
        services.AddHangfire(x => x.UseSqlServerStorage(config.GetConnectionString("DefaultConnection")));
        services.AddHangfireServer();
        
        // SignalR Service
        services.AddSignalR();





        return services;
    }   

    public static IApplicationBuilder UseApplicationMiddleware(this IApplicationBuilder app)
    {
        app.UseSession();
        app.UseHangfireDashboard("/HangfireDashboard");

        /*app.UseWebSockets();*/
            
        return app;
    }
}
