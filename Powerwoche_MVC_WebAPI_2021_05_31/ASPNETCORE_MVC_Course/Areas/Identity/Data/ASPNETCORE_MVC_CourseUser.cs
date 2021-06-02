using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ASPNETCORE_MVC_Course.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ASPNETCORE_MVC_CourseUser class
    public class ASPNETCORE_MVC_CourseUser : IdentityUser
    {
        public string FavoriteEis { get; set; }
    }
}
