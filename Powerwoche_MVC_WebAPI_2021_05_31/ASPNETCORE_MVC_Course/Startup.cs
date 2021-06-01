using ASPNETCORE_MVC_Course.Models;
using DependencyInjectionsSampleLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;
using Microsoft.EntityFrameworkCore;
using ASPNETCORE_MVC_Course.Data;

namespace ASPNETCORE_MVC_Course
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } //Appsettings.json in Memory (ist geladen) 

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //IServiceCollection = IOC-Containter ->Verwendungsonzept = seperation of concerns 
        {
            //.AddRazorRuntimeCompilation(); -> befindet sich in diesem Package (muss installiert (Package Manager) werden) -> Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); //Ich arbeite mit MVC (MVC Framework wird mit eingebunden
            services.AddLiveReload();

            #region Tag 1 - M�gliche ASP.NET Core framework technologien einginden (RazorPages, WebAPI.....)
            //Konvetionen f�r AddControllersWithViews = ben�tigt ein Verzeichnis mit dem Namen Controllers + Views

            //services.AddControllers(); //WebAPI 
            //Konvention f�r AddControllers -> Ben�tigt Controller Verziechnis

            //Wenn MVC + WebAPI in einem Projekt stehen sollten, dann w�re es sinnvoll, ein Controller/API Verzeichnis f�r die WebAPI Controller Klassen zu verwednen.

            //services.AddRazorPages(); //Razor Page Framework wird mit eingebunden
            //Konvention f�r RazorPages -> Ben�tigt das Pages-Verzeichnis

            //services.AddMvc(); // -> AddControllersWithViews & AddRazorPages (wird intern aufgerufen) 
            #endregion

            services.AddSingleton(typeof(ICar), typeof(MockCar));
            services.AddSingleton(typeof(ICar), typeof(Car)); //Car �berschreibt MockCar

            services.Configure<SampleWebSettings>(Configuration);


            //Intern wird hier das EF Core (DbContext-Klasse-> ASPNETCORE_MVC_CourseContext) mit der SCOPE-Lifetime definiert. 
            //Bei jedem Request bekommen wir einen frischen Datenstand
            services.AddDbContext<MovieDbContext>(options =>
                    options.UseInMemoryDatabase("MovieDB"));

            //services.AddTransient(typeof(ICarService), typeof(CarService));
            //services.AddScoped(typeof(ICar), typeof(Car));
            //services.AddScoped<ICar, Car>();


            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //Exceptions mit CallStack sind f�r Entwickler 
                app.UseLiveReload();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); //Bentuzerdefinierte Fehlerseite (Bitte kontaktieren sie den Administrator) 
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts(); //Erweiterte Sicherheit zum Thema HTTPS 
            }

            //Allgemeinen Feature-Einbindungen
            app.UseHttpsRedirection(); //https://localhost:12345/Home/Index -> https kann verwendet werden
            app.UseStaticFiles(); //wwwroot verzeichnis wird auch als statisch angesehen. 

            app.UseRouting(); //Routing -> Umleitung von Seite A nach B -> Routing-Pattern sind jetzt m�glich
             
            app.UseAuthorization(); //Authrization -> AuthSchema ist vorhanden
            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); //Default Muster f�r URL Aufbau

                //Default https://localhost:12345/ [Enter] -> l�st auf Startseite auf -> https://localhost:12345/Home/Index
            });
        }
    }
}
