using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SovTech.Common.Services;
using SovTech.Core.Services;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;

namespace SovTech.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddSwaggerGen(swagger =>
            {
                var version = "v1";

                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = "Template",
                    Version = version,
                    Description = "Template API",
                    Contact = new OpenApiContact
                    {
                        Name = "Template"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX"
                    }
                });
            });

            services.AddSingleton<IChuckService, ChuckService>();
            services.AddSingleton<ISearchService, SearchService>();
            services.AddSingleton<ISwapiService, SwapiService>();
            services.AddSingleton<ISharedService, SharedService>();
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
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template.API v1"));
            app.UseMvc();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/
        }
    }
}
