using ASPNETCORE_MVC_Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course.ViewModels
{
    public class MovieOverviewVM
    {
        public MovieOverviewVM()
        {

        }
        public Movie Movie { get; set; }

        public IList<Artists> Casts { get; set; }

        public BlueRay BlueRay { get; set; }
    }
}
