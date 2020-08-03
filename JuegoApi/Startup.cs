using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuegoApi.Data;
using JuegoApi.Data.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JuegoApi
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
            services.AddControllers();
            //MongoDb

            services.Configure<ClientesStoreDatabaseSettins>(Configuration.GetSection(nameof(ClientesStoreDatabaseSettins)));
            services.AddSingleton<IClientesStoreDatabaseSettins>(sp=>sp.GetRequiredService<IOptions<ClientesStoreDatabaseSettins>>().Value);
            services.AddSingleton<ClientesDb>();
            services.AddSingleton<RuletasDb>();
            services.AddSingleton<ApuestasDb>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
