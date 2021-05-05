using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using Pdbc.Idp.Data;

namespace Pdbc.Idp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddMvc();
            //services.AddCors();

            var identityServerDBConnectionString =
                Configuration["ConnectionStrings:IdentityServerDBConnectionString"];

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            // Setup Identity Server 4
            services.AddIdentityServer()
                .AddInMemoryCaching()


                .AddTestUsers(IdpUsers.GetUsers())
                .AddInMemoryApiScopes(IdpApiScopes.GetScopes())
                .AddInMemoryIdentityResources(IdpIdentityResources.GetIdentityResources())
                .AddInMemoryApiResources(IdpApiResources.GetApiResources())
                .AddInMemoryClients(IdpClients.GetClients())

                //.AddConfigurationStore(options =>
                //{
                //    options.ConfigureDbContext = b => b.UseSqlServer(identityServerDBConnectionString,
                //        sql => sql.MigrationsAssembly(migrationsAssembly));
                //})
                //.AddOperationalStore(options =>
                //{
                //    options.ConfigureDbContext = b => b.UseSqlServer(identityServerDBConnectionString,
                //        sql => sql.MigrationsAssembly(migrationsAssembly));
                //})

                .AddClientStore<InMemoryClientStore>()
                .AddResourceStore<InMemoryResourcesStore>()
                .AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    options.ClientId = "925417044554-bsjt1rtt0npu421equo2elurn6h9639i.apps.googleusercontent.com";
                    options.ClientSecret = "AEEo2KVJwwP-gECRgcvTgocj";

                    options.Events = new Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents()
                    {
                        OnCreatingTicket = context =>
                        {
                            var claims = new List<Claim>();
                            claims.AddRange(context.Principal.Claims);
                            claims.Add(new Claim("tenant", "belgianstatedepartment"));

                            // overwrite the old principal 
                            context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Google"));

                            return Task.CompletedTask;
                        },
                        OnTicketReceived = context =>
                        {
                            var test = context.Principal;
                            return Task.CompletedTask;
                        }
                    };
                });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pdbc.Idp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pdbc.Idp v1"));
            }

            // allow CORS requests (JavaScript) - any origin for demo purposes
            app.UseCors(c => c.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());

            app.UseIdentityServer();
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
