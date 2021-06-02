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
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.IO;
using ASPNETCORE_MVC_Course.Middleware;

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
            services.AddMvc().AddRazorRuntimeCompilation(); //Ich arbeite mit MVC (MVC Framework wird mit eingebunden
            services.AddLiveReload();

            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                 {
                    new CultureInfo("en"),
                    new CultureInfo("de"),
                    new CultureInfo("fr"),
                    //new CultureInfo("es"),
                    //new CultureInfo("ru"),
                    //new CultureInfo("ja"),
                    //new CultureInfo("ar"),
                    //new CultureInfo("zh"),
                    //new CultureInfo("en-GB")
                };
                options.DefaultRequestCulture = new RequestCulture("de");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

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

            services.AddAuthentication();
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

            app.UseAuthentication();
            app.UseAuthorization(); //Authrization -> AuthSchema ist vorhanden
            app.UseSession();

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);




            #region Middleware Use(mit next()) und Run
            app.Use(async (context, next) =>
            {
                //Request
                //await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
                
                await next(); //Gehen wir zur nächsten Middleware 

                //Response
                //await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
            });

            app.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("Before Invoke from 2nd app.Use()\n");
                await next(); //Gehen wir zur nächsten Middleware 
                //await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
            });

            //Terminierte Middleware
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from 1st app.Run()\n");
            //});
            #endregion

            #region Middleware einbinden mit Map


            //Request                         Response
            //https://localhost:44362/        Hello from app.Run()
            //https://localhost:44362/m1      Hello from 1st app.Map()
            //https://localhost:44362/m1/xyz  Hello from 1st app.Map()
            //https://localhost:44362/m2      Hello from 2nd app.Map()
            //https://localhost:44362/m500    Hello from app.Run()

            //app.Map("/m1", HandleMapOne);
            //app.Map("/m2", appMap =>
            //{
            //    appMap.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello from 2nd app.Map()");
            //    });
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from app.Run()");
            //});
            #endregion


            AppDomain.CurrentDomain.SetData("BildVerzeichnis", env.WebRootPath);


            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/images"
            });


            //app.UseThumbnailGen();
            app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
            {
                subapp.UseThumbnailGen();
            });


            app.UseEndpoints(endpoints =>
            {
                //Default Route

                // https://localhost:12345/Home/Index/
                // https://localhost:12345/Home/
                // https://localhost:12345/

                //endpoints.MapControllerRoute(
                //    name: "movie",
                //    pattern: "movie/{*movie}",defaults: new { controller = "Movie", action = "Index" });



                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); //Default Muster f�r URL Aufbau



                endpoints.MapRazorPages();
                //Default https://localhost:12345/ [Enter] -> l�st auf Startseite auf -> https://localhost:12345/Home/Index
            });
        }

        #region Beispiel Map
        private static void HandleMapOne(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 1st app.Map()");
            });
        }
        #endregion
    }
}
