using System;
using LletraWeb.Areas.Identity.Data;
using LletraWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LletraWeb.Areas.Identity.IdentityHostingStartup))]
namespace LletraWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LletraWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LletraWebContextConnection")));

                services.AddDefaultIdentity<LletraWebUser>()
                    .AddEntityFrameworkStores<LletraWebContext>();
            });
        }
    }
}