using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNETCORE_MVC_Course.Models;

namespace ASPNETCORE_MVC_Course.Data
{

    
    public class MovieDbContext : DbContext //DbContext -> EFCore
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<ASPNETCORE_MVC_Course.Models.Movie> Movie { get; set; } //Tabelle Movie kann via MovieDBContext benutzt werden
        public DbSet<ASPNETCORE_MVC_Course.Models.Artists> Artists { get; set; }
        public DbSet<ASPNETCORE_MVC_Course.Models.MovieCast> MovieCast { get; set; }
    }
}
