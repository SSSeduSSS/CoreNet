
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeguridadCORE.Data;

namespace SeguridadCORE
{
    public class Startup
    {
        IConfiguration configuration;//Para poder acceder a los archivos de configuración

        public Startup(IConfiguration configuration) {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    this.configuration.GetConnectionString("cadenaaspnet"))
                );

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

            //Hasta aquí funciona igual para cualquier proveedor, sea de microsoft, google, twitter, facebook...

            //Para microsoft:
            services.AddAuthentication().AddMicrosoftAccount(
                options => {
                //Estos datos son los que me ha dado microsoft desde  https://apps.dev.microsoft.com
                    options.ClientId= this.configuration["Authentication:Microsoft:ApplicationId"];
                    options.ClientSecret = this.configuration["Authentication:Microsoft:Password"]; ;
                }
            );

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
