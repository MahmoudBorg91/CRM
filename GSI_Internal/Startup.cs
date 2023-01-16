using GSI_Internal.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GSI_Internal.Extensions;
using GSI_Internal.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace GSI_Internal
{
    public class Startup
    {
     

        public Startup( IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            // Add services to the container.

            services.AddControllers();
            services.AddControllersWithViews();
            services.AddEndpointsApiExplorer();
            services.AddMvc(o => o.EnableEndpointRouting = false);
            services.AddDistributedMemoryCache();

            // api Services
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true); // validation Error Api
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // context && json services && IBaseRepository && IUnitOfWork Service
            services.AddContextServices( Configuration);

            // Services [IAccountService, IPhotoHandling, AddAutoMapper, Hangfire ,
            // Session , SignalR ,[ INotificationService, FcmNotificationSetting, FcmSender,ApnSender ]  ]
            services.AddApplicationServices( Configuration);

            // Identity services && JWT
            services.AddIdentityServices( Configuration);

            // External Login Services
            services.AddExternalLoginServices( Configuration);

            // Swagger Service
            services.AddSwaggerDocumentation();
            
            // cookies services
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Login";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
           
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin();
                        policy.AllowAnyMethod();
                        policy.AllowAnyHeader();
                    });
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }
            else
            {
                app.UseMiddleware<ExceptionMiddleware>();
                app.UseExceptionHandler("/ErrorsMvc/Index/{0}");
            }
            app.UseSwaggerDocumentation();
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseApplicationMiddleware();

            //app.MapHub<ChatHub>("/chatHub");
            //app.MapControllers();
            
            
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
