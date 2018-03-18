using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PlurarsiteDemoCore2.Models;

namespace PlurarsiteDemoCore2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // creates a new instance of MockPie Repository every time we call Ipie repository

            services.AddTransient<IPieRepository, MockPieRepository>();
            services.AddTransient<IIceCreamRepository, MockIcereamRepository>();

            // services.AddSingleton - same instance is always going to be returned.
            // services.AddScoped - returns instances within the scope. Per request it will always return the same instance.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseMvcWithDefaultRoute();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }


    }
}
