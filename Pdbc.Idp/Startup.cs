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
using System.Threading.Tasks;
using IdentityServer4.Stores;
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
            services.AddMvc();
            services.AddCors();

            var identityServerDBConnectionString =
                Configuration["ConnectionStrings:IdentityServerDBConnectionString"];


            // Setup Identity Server 4
            services.AddIdentityServer()
                .AddInMemoryCaching()


                .AddTestUsers(IdpUsers.GetUsers())
                .AddInMemoryApiScopes(IdpApiScopes.GetScopes())
                .AddInMemoryIdentityResources(IdpIdentityResources.GetIdentityResources())
                .AddInMemoryApiResources(IdpApiResources.GetApiResources())
                .AddInMemoryClients(IdpClients.GetClients())

                .AddClientStore<InMemoryClientStore>()
                .AddResourceStore<InMemoryResourcesStore>()
                .AddDeveloperSigningCredential();

            services.AddControllers();

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
                endpoints.MapControllers();
            });
        }
    }
}
