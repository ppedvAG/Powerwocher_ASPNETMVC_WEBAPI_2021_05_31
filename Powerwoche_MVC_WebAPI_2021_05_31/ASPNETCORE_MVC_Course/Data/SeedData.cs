using ASPNETCORE_MVC_Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course.Data
{
    public class SeedData
    {
        public static void Initialize(MovieDbContext ctx)
        {
            if (!ctx.Movie.Any())
            {
                ctx.Movie.Add(new Movie { ID = 1, Title = "Jurrasic Park", Description = "Achtung vor dem T-Rex", Genre = Genre.Action, Price=12.99m });
                ctx.Movie.Add(new Movie { ID = 2, Title = "Schweigen der Lämmer", Description = "Horrorfilm", Genre = Genre.Horror, Price = 19.99m });
                ctx.Movie.Add(new Movie { ID = 3, Title = "ES", Description = "Clowns sind doch lustig", Genre = Genre.Horror , Price = 9.99m });
                ctx.Movie.Add(new Movie { ID = 4, Title = "Le Mans 66", Description = "24 Stunden von Le Mans", Genre = Genre.Action, Price = 19.99m });

                ctx.SaveChanges(); //Hier werden alle hinzugefügten Datensätze an die "DB" übertragen -> Unit of Work Pattern!!
            }
        }
    }
}
