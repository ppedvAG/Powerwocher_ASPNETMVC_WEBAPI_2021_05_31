using System;
using ASPNETCORE_MVC_Course.Areas.Identity.Data;
using ASPNETCORE_MVC_Course.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASPNETCORE_MVC_Course.Areas.Identity.IdentityHostingStartup))]
namespace ASPNETCORE_MVC_Course.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ASPNETCORE_MVC_CourseContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ASPNETCORE_MVC_CourseContextConnection")));

                services.AddDefaultIdentity<ASPNETCORE_MVC_CourseUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ASPNETCORE_MVC_CourseContext>();
            });
        }
    }
}