using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Authentication;
using System;
using System.Text;

namespace MMIS.API.Infrastructure.Middleware
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            // For Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddUserManager<LdapUserManager<ApplicationUser>>()
                .AddEntityFrameworkStores<MMISDbContext>()
                .AddDefaultTokenProviders();


            var secret = config.GetSection("JWT").GetSection("Secret").Value;

            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuerSigningKey = true,
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });

            return services;
        }
    }
}
