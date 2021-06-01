using ASPNETCORE_MVC_Course.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult ViewDataSample()
        {
            //Normalerweise nimmt man ein Model oder ViewModel und übergbit es bei return View(obj)...
            ViewData["abc"] = "Hallo liebe Teilnehmer!";
            ViewData["def"] = "Auch das wird mit übergeben";
            return View();
        }

        public IActionResult ViewBagSample()
        {
            ViewBag.XYZ = "ViewBag basiert auf ViewData - XYZ sollte in der ViewData jetzt auch vorhanden sein";
            return View();
        }

        public IActionResult FirstTempDataSample()
        {
            TempData["EmailAddress"] = "KevinW@ppedv.de";
            TempData["Id"] = 123;
        

            return View();
        }

        public IActionResult SecondTempDataSample()
        {
            return View();
        }
        public IActionResult ThirdTempDataSample()
        {
            return View();
        }

        public IActionResult InitSession()
        {
            HttpContext.Session.SetString("Wetter", "Heute scheint nicht die Sonne");
            HttpContext.Session.SetInt32("Lottozahlen", 1234567);

            Movie movie = new Movie();
            movie.ID = 1;
            movie.Title = "ES";
            movie.Description = "Clown enthalten";

            string jsonString = JsonSerializer.Serialize(movie);
            HttpContext.Session.SetString("MovieObj", jsonString);

            return View();
        }
    }
}
