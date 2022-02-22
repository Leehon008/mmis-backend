using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MMIS.API.Infrastructure;
using MMIS.API.Infrastructure.Middleware;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Authentication;
using System;
using System.Text;

namespace MMIS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Connection string Configuration
            services.AddDbContext<MMISDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<LdapAuthenticationOptions>(this.Configuration.GetSection("ldap"));

            //Enabling Cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("*")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddControllers();
            services.AddTokenAuthentication(Configuration);

            // For Identity
            //services.AddIdentity<ApplicationUser, ApplicationRole>()
            //    .AddUserManager<LdapUserManager<ApplicationUser>>()
            //    .AddEntityFrameworkStores<MMISDbContext>()
            //    .AddDefaultTokenProviders();


            services.AddSingleton<IConfiguration>(Configuration);

            services.AddHttpContextAccessor();
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMemoryCache();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MMIS API",
                    Description = "REST Web API for the DELTA Front End MMIS",
                    Contact = new OpenApiContact
                    {
                        Name = "Digital",
                        Email = "itdev@delta.co.zw"
                    }
                });
                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            }
                //        },
                //        Array.Empty<string>()
                //    }
                //});
            });
            return new ServiceResolver(services).GetServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MMIS API V1");
            });


            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()); // allow credentials

            app.UseHttpsRedirection();

           
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<UnitOfWorkMiddleware>();
        }
    }
}
