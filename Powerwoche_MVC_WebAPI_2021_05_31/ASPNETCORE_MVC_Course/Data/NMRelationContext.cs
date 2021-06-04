using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNETCORE_MVC_Course.Models;

namespace ASPNETCORE_MVC_Course.Data
{

    
    public class NMRelationContext : DbContext //DbContext -> EFCore
    {
        public NMRelationContext(DbContextOptions<NMRelationContext> options)
            : base(options)
        {
        }

        public DbSet<ASPNETCORE_MVC_Course.Models.Post> Posts { get; set; } //Tabelle Movie kann via MovieDBContext benutzt werden
        public DbSet<ASPNETCORE_MVC_Course.Models.Tag> Tags { get; set; }
    }
}
