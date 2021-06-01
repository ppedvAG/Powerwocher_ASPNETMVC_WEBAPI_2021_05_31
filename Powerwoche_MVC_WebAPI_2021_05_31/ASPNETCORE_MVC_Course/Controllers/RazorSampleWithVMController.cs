using ASPNETCORE_MVC_Course.Models;
using ASPNETCORE_MVC_Course.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course.Controllers
{
    public class RazorSampleWithVMController : Controller
    {
        public IActionResult Index()
        {
            MovieOverviewVM movieOverviewVM = new MovieOverviewVM();
            movieOverviewVM.Movie = new Models.Movie()
            {
                ID = 1,
                Genre = Models.Genre.Horror,
                Title = "ES",
                Description = "Irgendwas mit einem freundlichen Clown ;-) "
            };

            if (movieOverviewVM.Casts == null)
                movieOverviewVM.Casts = new List<Artists>();

            movieOverviewVM.Casts.Add(new Models.Artists
            {
                Id = 1,
                Firstname = "Maria",
                Lastname = "Musterfrau"
            });
            movieOverviewVM.Casts.Add(new Models.Artists
            {
                Id = 1,
                Firstname = "Max",
                Lastname = "Mustermann"
            });


            movieOverviewVM.BlueRay = new BlueRay()
            {
                Id = 1,
                MovieId = 11212312,
            };


            return View(movieOverviewVM);
        }

        public IActionResult ShowEasyList()
        {
            IList<Artists> artists = new List<Artists>();
            artists.Add(new Models.Artists
            {
                Id = 1,
                Firstname = "Maria",
                Lastname = "Musterfrau"
            });
            artists.Add(new Models.Artists
            {
                Id = 1,
                Firstname = "Max",
                Lastname = "Mustermann"
            });

            return View(artists);
        }
    }
}
