using Microsoft.AspNetCore.Hosting;
[assembly: HostingStartup(typeof(GSI_Internal.Areas.Identity.IdentityHostingStartup))]
namespace GSI_Internal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }


    }
}
