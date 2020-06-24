using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Republics.Queries.GetAllRepublics;
using Application.Commands.Statistics.Queryes.GetStatisticList;
using Application.Interfaces;
using Domain.Entity;
using Infrastructure_;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace COVIDApplicationUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var host=  CreateHostBuilder(args).Build();
            using (var servisec =host.Services.CreateScope())
            {
                var RoleManager = servisec.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = servisec.ServiceProvider.GetRequiredService<AppDBContext>();
                var MediatR = servisec.ServiceProvider.GetRequiredService<IMediator>();


              
               var Doctor = new IdentityRole("Doctor");
               var User = new IdentityRole("User");
               var Admin = new IdentityRole("Admin");
               if (!context.Roles.Any())
               {
                   RoleManager.CreateAsync(Admin).GetAwaiter().GetResult();
                   RoleManager.CreateAsync(Doctor).GetAwaiter().GetResult();
                   RoleManager.CreateAsync(User).GetAwaiter().GetResult();
               }
                
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>();
                });
    }
}
