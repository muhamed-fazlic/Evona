using Evona.Task.Application.Contracts.Identity;
using Evona.Task.Application.Models.Identity;
using Evona.Task.Identity.Models;
using Evona.Task.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Evona.Task.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigurationIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<EvonaTaskIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EvonaTaskIdentityConnectionString"),
            x => x.MigrationsAssembly(typeof(EvonaTaskIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole<int>>().AddEntityFrameworkStores<EvonaTaskIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();

            services
                .AddAuthentication(options => { options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };
                });

            return services;
        }
    }
}
