using Application.Interfaces;
using Application.Models.Interfaces;
using Application.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Infrastructure_.Models;
using Application.Commands.Articles.CreateArticle;
using Infrastructure_.ParserStatistic;
using Application.Commands.Statistics.Queryes.GetStatisticList;
using AngleSharp.Html.Dom;
using CsQuery;
using Infrastructure_.ParserRepublic;

namespace Infrastructure_
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure_(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(
                     configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedEmail = true)
                .AddRoleManager<ApplicationRoleManager>()
                .AddEntityFrameworkStores<AppDBContext>()
                .AddDefaultTokenProviders();
            
            services.AddMediatR(Assembly.GetExecutingAssembly(),typeof(GetStatisticListVm).Assembly);
            
            services.AddScoped<IUserManager, UserManagerService>();

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<IParser<StatisticDto_, CQ>, StatisticParser>();
            services.AddTransient<IParserSettings<StatisticDto_>, StatisticParserSettings>();

            services.AddTransient<IParser<Republic, CQ>, RepublicsParser>();
            services.AddTransient<IParserSettings<Republic>, RepublicParserSettings>();

            services.AddScoped<ICovidDbContext>(provider => provider.GetService<AppDBContext>());
            services.AddAuthentication();
            services.AddAuthorization();
            return services;
        }
    }
}
