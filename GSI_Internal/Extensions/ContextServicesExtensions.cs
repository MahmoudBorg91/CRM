using System;
using System.Text.Json.Serialization;
using GSI_Internal.Context;
using GSI_Internal.Filters;
using GSI_Internal.Repositry.ApiRepositry.Repositories;
using GSI_Internal.Repositry.Application_Status_Repo;
using GSI_Internal.Repositry.ApplicationTransaction_Request_Log_Repo;
using GSI_Internal.Repositry.ApplicationTransaction_RequestRepo;
using GSI_Internal.Repositry.ApplicationTransferRepo;
using GSI_Internal.Repositry.AssignInquireytToItemRepo;
using GSI_Internal.Repositry.AssignRequirmentToItemRepo;
using GSI_Internal.Repositry.AssignSelectionToItem_Repo;
using GSI_Internal.Repositry.DashboardRepo;
using GSI_Internal.Repositry.HomeRepo;
using GSI_Internal.Repositry.RequestInquiry_AnswerRepo;
using GSI_Internal.Repositry.RequestSelection_GroupRepo;
using GSI_Internal.Repositry.RequestSelection_SelectedRepo;
using GSI_Internal.Repositry.RequirementsRepo;
using GSI_Internal.Repositry.RequirmentsFileAttachmentRepo;
using GSI_Internal.Repositry.SlideShowRepo;
using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionItemInquiryRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using GSI_Internal.Repositry.TransiactionItem_Selection_Repo;
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

        
         
        
        //------------------------------------------------------------------------------------------------------------------
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddScoped<ITransactionGroupRepo, TransactionGroupRepo>();
        services.AddScoped<ITransactionItemRepo, TransactionItemRepo>();
        services.AddScoped<IHomeRepo, HomeRepo>();
        services.AddScoped<ITransactionSubGroupRepo, TransactionSubGroupRepo>();
        services.AddScoped<IRequirementsRepo, RequirementsRepo>();
        services.AddScoped<IAssignRequirmentToItemRepo, AssignRequirmentToItemRepo>();
        services.AddScoped<IApplicationTransaction_RequestRepo, ApplicationTransaction_RequestRepo>();
        services.AddScoped<IDashboardRepo, DashboardRepo>();
        services.AddScoped<IApplicationTransaction_Request_LogRepo, ApplicationTransaction_Request_LogRepo>();
        services.AddScoped<IAppliactionTransferRepo, ApplicationTranserRepo>();
        services.AddScoped<IApplication_StatusRepo, Application_StatusRepo>();
        services.AddScoped<IRequirmentsFileAttachmentRepo, RequirmentsFileAttachmentRepo>();
        services.AddScoped<ITransactionItemInquiryReop, TransactionItemInquiryRepo>();
        services.AddScoped<IAssignInquireytToItemRepo, AssignInquireytToItemRepo>();
        services.AddScoped<IRequestInquiry_AnswerRpo, RequestInquiry_AnswerRepo>();
        services.AddScoped<IAssignSelectionToItemRepo, AssignSelectionToItemRepo>();
        services.AddScoped<ITransiactionItem_SelectionRepo, TransiactionItem_SelectionRepo>();
        services.AddScoped<IRequestSelection_Selectes, RequestSelection_Selectes>();
        services.AddScoped<IRequestSelection_GroupRepo, RequestSelection_GroupRepo>();
        services.AddScoped<ISlideShowRepo, SlideShowRepo>();

        services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.Zero;
        });

        //----------------------------------------------------------------------------------------------------------------------
        return services;
    }
       
}
