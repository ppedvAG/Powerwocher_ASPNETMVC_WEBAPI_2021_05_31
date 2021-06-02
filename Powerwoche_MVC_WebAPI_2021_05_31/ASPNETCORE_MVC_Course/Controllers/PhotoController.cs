﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course.Controllers
{
    public class PhotoController : Controller
    {
        //Get Methode -> Anzeigen des Upload Formulars
        public IActionResult UploadPicture()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadPicture(IFormFile datei)
        {
            FileInfo fileInfo = new FileInfo(datei.FileName);

            var speicherPfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileInfo.Name;

            using (var fs = new FileStream(speicherPfad, FileMode.Create))
            {
                datei.CopyTo(fs);
            }


            return RedirectToAction(nameof(Index));
        }


        //Anzeigen einer unformartierten Gallery
        public IActionResult Index()
        {
            var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";

            string[] bilder = Directory.GetFiles(pfad);

            return View(bilder);
        }

        public IActionResult IndexRough()
        {
            var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";

            string[] bilder = Directory.GetFiles(pfad);

            return View(bilder);
        }


         
    }
}
