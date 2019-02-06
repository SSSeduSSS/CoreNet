using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreVacio.Data;
using CoreVacio.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoCore.Data;

namespace CoreVacio
{
    public class Startup
    {
        IConfiguration configuration;
        //Esta clase también con Inyeccion de dependencias
        public Startup(IConfiguration configuration) {
            //Esta clase permita acceder a los archivos de configuración
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Aqui se realiza la inversion de control(IoC) para la inyeccion de depedencias
            String cadenaConexionSQL = this.configuration.GetConnectionString("cadenaHospital");
            String cadenaConexionMYQL = this.configuration.GetConnectionString("cadenaHospitalMYSQL1");

            //Para poner un objeto en la app para que resuelva las dependencias=>AddTransient
            services.AddTransient<RepositoryHospital>();
            //Los contexts con AddDbContext para poder darle las opciones
            //services.AddDbContext<HospitalContext>(
            //    options=>options.UseSqlServer(cadenaConexion));

            //services.AddDbContext<IRepositoryHospital, HospitalContextSQL>
            //    (options => options.UseSqlServer(cadenaConexionSQL));

            services.AddDbContext<IHospitalContext, HospitalContextMySql>
                (options => options.UseMySql(cadenaConexionMYQL));

            //Arranque del servicio del midelware
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
//En caso de que estoy en Development lanzo esta  página para mostrarlo
                app.UseDeveloperExceptionPage(); 
            }

            //4-Utilizamos archivos de wwwroot
            app.UseStaticFiles();


            //8-debemos indicar la ruta de inicio
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
        }


    }
}
