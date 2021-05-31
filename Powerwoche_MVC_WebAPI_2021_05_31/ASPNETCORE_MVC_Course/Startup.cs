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

            #region Tag 1 - Mögliche ASP.NET Core framework technologien einginden (RazorPages, WebAPI.....)
            //Konvetionen für AddControllersWithViews = benötigt ein Verzeichnis mit dem Namen Controllers + Views

            //services.AddControllers(); //WebAPI 
            //Konvention für AddControllers -> Benötigt Controller Verziechnis

            //Wenn MVC + WebAPI in einem Projekt stehen sollten, dann wäre es sinnvoll, ein Controller/API Verzeichnis für die WebAPI Controller Klassen zu verwednen.

            //services.AddRazorPages(); //Razor Page Framework wird mit eingebunden
            //Konvention für RazorPages -> Benötigt das Pages-Verzeichnis

            //services.AddMvc(); // -> AddControllersWithViews & AddRazorPages (wird intern aufgerufen) 
            #endregion

            services.AddSingleton(typeof(ICar), typeof(MockCar));
            services.AddSingleton(typeof(ICar), typeof(Car)); //Car überschreibt MockCar

            services.Configure<SampleWebSettings>(Configuration);

            //services.AddTransient(typeof(ICarService), typeof(CarService));
            //services.AddScoped(typeof(ICar), typeof(Car));
            //services.AddScoped<ICar, Car>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //Exceptions mit CallStack sind für Entwickler 
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

            app.UseRouting(); //Routing -> Umleitung von Seite A nach B -> Routing-Pattern sind jetzt möglich
             
            app.UseAuthorization(); //Authrization -> AuthSchema ist vorhanden



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); //Default Muster für URL Aufbau

                //Default https://localhost:12345/ [Enter] -> löst auf Startseite auf -> https://localhost:12345/Home/Index
            });
        }
    }
}
