using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVIDApplicationUI
{
    public static class DependencyInjection
    {
        public static IServiceCollection UseAnotherAutorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = configuration["Facebook:AppId"];
                    facebookOptions.AppSecret = configuration["Facebook:AppSecret"];

                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = configuration["Google:AppId"];
                    googleOptions.ClientSecret = configuration["Google:AppSecret"];
                });


            return services;
        }
    }
}
