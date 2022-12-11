using GSI_Internal.Context;
using GSI_Internal.Filters;
using GSI_Internal.Repositry;

using GSI_Internal.Repositry.Application_Status_Repo;
using GSI_Internal.Repositry.ApplicationTransaction_Request_Log_Repo;
using GSI_Internal.Repositry.ApplicationTransaction_RequestRepo;
using GSI_Internal.Repositry.ApplicationTransferRepo;
using GSI_Internal.Repositry.AssignRequirmentToItemRepo;
using GSI_Internal.Repositry.DashboardRepo;


using GSI_Internal.Repositry.HomeRepo;
using GSI_Internal.Repositry.RequirementsRepo;
using GSI_Internal.Repositry.RequirmentsFileAttachmentRepo;

using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using GSI_Internal.Entites;
using GSI_Internal.Repositry.AssignInquireytToItemRepo;
using GSI_Internal.Repositry.AssignSelectionToItem_Repo;
using GSI_Internal.Repositry.FileUploadServicesRepo;
using GSI_Internal.Repositry.RequestInquiry_AnswerRepo;
using GSI_Internal.Repositry.RequestSelection_GroupRepo;
using GSI_Internal.Repositry.RequestSelection_SelectedRepo;
using GSI_Internal.Repositry.SlideShowRepo;
using GSI_Internal.Repositry.TransactionItemInquiryRepo;
using GSI_Internal.Repositry.TransiactionItem_Selection_Repo;
using Hangfire;

namespace GSI_Internal
{
    public class Startup
    {
        private readonly IConfiguration conf;

        public Startup(IConfiguration conf)
        {
            this.conf = conf;
        }



        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddDefaultTokenProviders().AddDefaultUI()
            //    .AddEntityFrameworkStores<dbContainer>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false )
               .AddEntityFrameworkStores<dbContainer>()
               .AddDefaultUI().AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContextPool<dbContainer>(ops => ops.UseSqlServer(conf.GetConnectionString("DefaultConnection")));
            services.AddSignalR();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            services.AddHangfire(x => x.UseSqlServerStorage(conf.GetConnectionString("Hangfire")));
            services.AddHangfireServer();
            //services.AddScoped<ICustommer, CustommerRepo>();
            //services.AddScoped<IApplicationRepo, ApplicationsRepo>();
            //services.AddScoped<ISoultionRepo, SoultionRepo>();
            //services.AddScoped<ILeadRepo, LeadRepo>();
            //services.AddScoped<IFollowUpRepo, FollowUpRepo>();
            //services.AddScoped<IDemoMainRepo, DemoMainRepo>();
            //services.AddScoped<IDemoSubRepo, DemoSubRepo>();
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











        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            //if (env.IsDevelopment())
            //{

            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseHangfireDashboard("/HangfireDashboard");
           
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<SignalrServer>("/signalrServer");
                endpoints.MapHub<SignalrServer>("/signalrServer/{id?}");


            });
        }
    }
}
