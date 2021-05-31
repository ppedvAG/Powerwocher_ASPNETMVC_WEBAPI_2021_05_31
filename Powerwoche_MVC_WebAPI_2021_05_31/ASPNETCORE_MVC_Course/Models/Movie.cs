using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
    }

    public enum Genre { Action=1, Comedy, Horror, Thriller, Romance, Animations }
}
