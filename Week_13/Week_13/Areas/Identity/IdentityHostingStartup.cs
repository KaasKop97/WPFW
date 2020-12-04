using System;
using ApplicationDbContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Week_13.Models;

[assembly: HostingStartup(typeof(Week_13.Areas.Identity.IdentityHostingStartup))]
namespace Week_13.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<cs>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("csConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<cs>();
            });
        }
    }
}