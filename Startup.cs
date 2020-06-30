using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forumweb_theback.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace forumweb_theback
{
    public class Startup
    {
        readonly string SignalRCors = "signalRCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option => {
                option.AddPolicy(name: SignalRCors,
                              builder =>
                              {
                                  builder.WithOrigins("http://localhost:4200")
                                                      .AllowCredentials()
                                                      .WithHeaders("x-requested-with")
                                                      .AllowAnyMethod();
                              });
            });
            services.AddControllers();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ControlHub>("/controlhub").RequireCors(SignalRCors);
            });
        }
    }
}
