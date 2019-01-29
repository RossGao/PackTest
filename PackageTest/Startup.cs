using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackageTest.BusinessLogics;
using PackageTest.Controllers;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace PackageTest
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
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddVManagement()
                .AddVersionStore(options =>
                {
                    options.ConfigDbContext = builder =>
                      builder.UseMySql(Configuration.GetConnectionString("Version"), sql => sql.MigrationsAssembly(migrationsAssembly));
                });

            services.AddScoped<VersionController>();
            services.AddScoped<VersionLogicHandler>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Package Test", Version = "v1" });
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, ".xml");
                c.IncludeXmlComments(xmlFile);
                //c.ResolveConflictingActions(apiDesc => apiDesc.Last());
                c.OperationFilter<AddHeaderOperationFilter>("api-version", "Indicate api version number", false); // Add http header for version parameter in swagger.
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Package Test API v1");
            });

            app.UseMvc();
        }
    }
}
