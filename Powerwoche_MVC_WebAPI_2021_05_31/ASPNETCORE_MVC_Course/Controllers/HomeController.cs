using ASPNETCORE_MVC_Course.Models;
using DependencyInjectionsSampleLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICar _myMockCar;

        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, ICar car, IConfiguration configuration)
        {
            _logger = logger;
            _myMockCar = car;
            _configuration = configuration;
        }


        //Index-Methode für die Startseite -> https:\\localhost\Home\Index
        public IActionResult Index() //Startseite 
        {
            PositionOptions positionOptions = new(); // ist das gleich wie PositionOptions positionOptions = new PositionOptions()
            _configuration.GetSection(PositionOptions.stringPosition).Bind(positionOptions);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
