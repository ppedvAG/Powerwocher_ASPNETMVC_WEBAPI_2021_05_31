﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course.Controllers
{
    public class PartialViewSampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
