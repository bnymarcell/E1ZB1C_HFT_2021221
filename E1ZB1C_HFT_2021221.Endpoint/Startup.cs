using E1ZB1C_HFT_2021221.Data;
using E1ZB1C_HFT_2021221.Logic;
using E1ZB1C_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ICompanyLogic, CompanyLogic>();
            services.AddTransient<ICarLogic, CarLogic>();
            services.AddTransient<IDriverLogic, DriverLogic>();

            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IDriverRepository, DriverRepository>();

            services.AddTransient<CompanyDbContext, CompanyDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
